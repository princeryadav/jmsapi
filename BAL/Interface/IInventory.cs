﻿using DTO.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IInventory
    {
        Task<SingleReturnResult<InventoryDto>> AddInventory(InventoryDto inventory);
        Task<SingleReturnResult<InventoryDto>> UpdateInventory(InventoryDto inventory);
        Task<ListReturnResult<InventoryDto>> GetInventoryList();
        Task<SingleReturnResult<InventoryDto>> GetInventoryById(int id);
    }
}
