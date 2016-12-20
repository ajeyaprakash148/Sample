using Common.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Helpers
{
    public static class AjaxHelper
    {
        public static AjaxModel<T> BlankModel<T>() where T : class
        {
            return new AjaxModel<T>() { Result = AjaxResult.Success, Data = null, Message = string.Empty };
        }

        public static async Task<AjaxModel<T>> GetAsync<T>(Func<string, Task<T>> action, string message = "")
        {
            AjaxModel<T> ajax;

            try
            {
                T model = await action(null);
                ajax = new AjaxModel<T>() { Result = AjaxResult.Success, Data = model, Message = message };
            }
            //catch (FxException exp)
            //{
            //    ajax = new AjaxModel<T>() { Result = AjaxResult.ValidationException, Model = default(T), Message = exp.Message };
            //}
            catch (Exception exp)
            {
                ajax = new AjaxModel<T>() { Result = AjaxResult.Exception, Data = default(T), Message = exp.GetBaseException().Message };
            }

            return ajax;
        }

        public static async Task<AjaxModel<DataModel>> SaveAsync(Func<string, Task> action, string message)
        {
            AjaxModel<DataModel> ajax;

            try
            {
                await action(null);

                ajax = new AjaxModel<DataModel>() { Result = AjaxResult.Success, Data = null, Message = message };
            }
            //catch (FxException exp)
            //{
            //    ajax = new AjaxModel<DataModel>() { Result = AjaxResult.ValidationException, Model = new DataModel() { Data = exp.Model }, Message = exp.Message };
            //}
            catch (Exception exp)
            {
                ajax = new AjaxModel<DataModel>() { Result = AjaxResult.Exception, Data = null, Message = exp.GetBaseException().Message };
            }

            return ajax;
        }

        public static async Task<AjaxModel<T>> SaveGetAsync<T>(Func<string, Task<T>> action, string message) where T : class
        {
            return await GetAsync(action, message);
        }
    }
}
