<script>
    document.addEventListener("DOMContentLoaded", function () {
    const sportTypeSelect = document.getElementById("sportType");
    const trainerSelect = document.getElementById("trainer");
    const appointmentDateInput = document.getElementById("appointmentDate");
    const appointmentTimeSelect = document.getElementById("appointmentTime");

    // 🔹 1️⃣ Spor Türü Seçilince Eğitmenleri Getir
    sportTypeSelect.addEventListener("change", async function () {
        const sportTypeId = this.value;
    trainerSelect.innerHTML = '<option value="">Eğitmenler yükleniyor...</option>';

    if (!sportTypeId) {
        trainerSelect.innerHTML = '<option value="">Önce spor türü seçiniz...</option>';
    return;
        }

    try {
            const response = await fetch(`/Appointment/GetTrainersBySportType?sportTypeId=${sportTypeId}`);
    const trainers = await response.json();

    trainerSelect.innerHTML = '<option value="">Eğitmen seçiniz...</option>';
            trainers.forEach(trainer => {
        trainerSelect.innerHTML += `<option value="${trainer.id}">${trainer.fullName}</option>`;
            });
        } catch (error) {
        console.error("Eğitmenleri alırken hata:", error);
        }
    });

    // 🔹 2️⃣ Eğitmen ve Tarih Seçilince Uygun Saatleri Getir
    trainerSelect.addEventListener("change", fetchAvailableTimes);
    appointmentDateInput.addEventListener("change", fetchAvailableTimes);

    async function fetchAvailableTimes() {
        const trainerId = trainerSelect.value;
    const appointmentDate = appointmentDateInput.value;

    appointmentTimeSelect.innerHTML = '<option value="">Saatler yükleniyor...</option>';

    if (!trainerId || !appointmentDate) {
        appointmentTimeSelect.innerHTML = '<option value="">Önce eğitmen ve tarih seçiniz...</option>';
    return;
        }

    try {
            const response = await fetch(`/Appointment/GetAvailableSchedules?trainerId=${trainerId}&date=${appointmentDate}`);
    const schedules = await response.json();

    appointmentTimeSelect.innerHTML = '<option value="">Saat seçiniz...</option>';
            schedules.forEach(schedule => {
        appointmentTimeSelect.innerHTML += `<option value="${schedule.startTime}">${schedule.startTime} - ${schedule.endTime}</option>`;
            });
        } catch (error) {
        console.error("Uygun saatleri alırken hata:", error);
        }
    }
});
</script>
