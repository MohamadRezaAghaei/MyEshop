﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;
using MyEshop.Data.Repositories;
using MyEshop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyEshop.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ProductGroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/ProductGroupsComponent.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
