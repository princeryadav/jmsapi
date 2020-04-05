﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using DTO.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventory _inventory;
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        [HttpPost]
        [Route("AddInventory")]
        public async Task<IActionResult> AddInventory([FromBody] InventoryDto inventory)
        {
            IActionResult response = Unauthorized();
            SingleReturnResult<InventoryDto> result = await _inventory.AddInventory(inventory);
            response = Ok(result);
            return response;
        }

        [HttpPost]
        [Route("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryDto inventory)
        {
                IActionResult response = Unauthorized();
                SingleReturnResult<InventoryDto> result = await _inventory.UpdateInventory(inventory);
                response = Ok(result); 
                return response;
        }

        [HttpGet]
        [Route("InventoryDetails")]
        public async Task<IActionResult> GetInventoryList()
        {
            IActionResult response = Unauthorized();
            ListReturnResult<InventoryDto> result = await _inventory.GetInventoryList();
            response = Ok(result);
            return response;
        }

        [HttpGet("{id}")]
        //[Route("GetInventoryById")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            IActionResult response = Unauthorized();
            SingleReturnResult<InventoryDto> result = await _inventory.GetInventoryById(id);
            response = Ok(result);
            return response;
        }
    }
}