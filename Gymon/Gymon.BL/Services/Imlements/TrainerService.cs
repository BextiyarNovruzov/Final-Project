using AutoMapper;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.TrainnerVMs;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Gymon.BL.Services.Imlements
{
    public class TrainerService(ITrainerRepository _trainerRepository,
        ISportTypeRepository sportTypeRepo,
        ITrainerScheduleRepository _trainerScheduleRepository,
        IMapper _mapper,
        IWebHostEnvironment web,
        IFileService _fileService) : ITrainerService
    {
        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            return await _trainerRepository.GetAllAsync();
        }


        public async Task<bool> CreateAsync(CreateTrainerVM model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            // Map the ViewModel to the entity
            var trainer = _mapper.Map<Trainer>(model);

            // Handle the image upload
            string uploadsFolder = "imgs/trainers";
            string imageUrl = await _fileService.SaveImageAsync(model.Image, uploadsFolder);

            // Set the image URL
            trainer.ImageUrl = "/imgs/trainers/" + imageUrl;

            // Save the trainer entity
            await _trainerRepository.AddAsync(trainer);

            // Save changes to the database
            return await _trainerRepository.SaveAsync() > 0;
        }


        public async Task DeleteTrainerAsync(int id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            if (trainer != null)
            {
                await _trainerRepository.DeleteAsync(id);
            }
        }
        public async Task<Trainer> GetTrainerByIdAsync(int id)
        {
            return await _trainerRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateTrainerAsync(UpdateTrainerVM updateTrainerVM, IFormFile newImage)
        {
            var existingTrainer = await _trainerRepository.GetByIdAsync(updateTrainerVM.Id);
            if (existingTrainer == null)
                return false;

            // TrainerSportTypes güncellenmesi
            existingTrainer.TrainerSportTypes.Clear();
            foreach (var sportTypeId in updateTrainerVM.TrainerSportTypesId)
            {
                existingTrainer.TrainerSportTypes.Add(new TrainerSportType
                {
                    TrainerId = existingTrainer.Id,
                    SportTypeId = sportTypeId
                });
            }

            // Diğer bilgileri güncelle
            _mapper.Map(updateTrainerVM, existingTrainer);

            // Resmi güncelle
            if (newImage != null)
            {
                await UpdateTrainerImageAsync(existingTrainer.Id, newImage);
            }

            await _trainerRepository.UpdateAsync(existingTrainer);
            return true;
        }

        public async Task<bool> UpdateTrainerImageAsync(int trainerId, IFormFile newImage)
        {
            var trainer = await _trainerRepository.GetByIdAsync(trainerId);

            if (trainer == null)
                return false;

            // Eğer yeni bir resim yüklenmemişse, mevcut resim korunur
            if (newImage == null)
                return true;

            // Resmi kaydetme işlemi
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgs/trainers");
            string newImageUrl = await _fileService.SaveImageAsync(newImage, uploadsFolder);

            // Eski resmi silme işlemi (eğer varsa)
            if (!string.IsNullOrEmpty(trainer.ImageUrl))
            {
                string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", trainer.ImageUrl.TrimStart('/'));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            // Yeni resmi güncelle
            trainer.ImageUrl = "/imgs/trainers/" + newImageUrl;

            await _trainerRepository.UpdateAsync(trainer);
            return true;
        }
        public async Task<IEnumerable<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId)
        {
            return await _trainerRepository.GetTrainersBySportTypeAsync(sportTypeId);
        }

        public async Task<List<TrainerSchedule>> GetAvailableTimes(int trainerId)
        {
            var trainer = await _trainerRepository.GetByIdAsync(trainerId);
            if (trainer == null)
            {
                throw new ArgumentException("Trainer not found.");
            }

            // Eğitmenin müsait olduğu saatleri TrainerScheduleRepository üzerinden al
            var availableTimes = await _trainerScheduleRepository.GetAvailableTimesByTrainerIdAsync(trainerId);

            return availableTimes;
        }
        public async Task<decimal> GetTrainerHourlyRate(int trainerId)
        {
            // Eğitmeni ID'si ile buluyoruz
            var trainer = await _trainerRepository.GetByIdAsync(trainerId);

            if (trainer == null)
            {
                throw new ArgumentException("Trainer not found.");
            }

            // Eğitmenin saatlik ücretini döndürüyoruz
            return trainer.HourlyRate;
        }
    }
}
