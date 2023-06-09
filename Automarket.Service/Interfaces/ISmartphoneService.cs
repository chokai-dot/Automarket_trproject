﻿using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Smartphone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.Service.Interfaces
{
    internal interface ISmartphoneService
    {
        //BaseResponse<Dictionary<int, string>> GetTypes();

        IBaseResponse<List<Smartphone>> GetSmartphones();

        Task<IBaseResponse<SmartphoneViewModel>> GetSmartphone(int id);

        Task<BaseResponse<Dictionary<int, string>>> GetSmartphone(string term);

        Task<IBaseResponse<Smartphone>> Create(SmartphoneViewModel smartphone, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteSmartphone(int id);

        Task<IBaseResponse<Smartphone>> Edit(int id, SmartphoneViewModel model);
    }
}
