﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Domain;

namespace Website.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", _dataManager.ServiceItems.GetServiceItems()));
        }
    }
}