﻿using Gymon.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles =nameof(Roles.Admin))]

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
