using EasyMenu.Application.Contracts.Response;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;

namespace EasyMenu.Application.Helpers
{
    public static class Utils
    {
        public static ResultData SuccessData(DefaultResponse _data)
        {
            bool _error = _data.HasErrors == false ? true : false;

            var result = new ResultData(_data, _error);
            return result;
        }

        public static ResultData SuccessData(object _data)
        {
            var result = new ResultData(_data, true);
            return result;
        }
        public static ResultData ErrorData(object _data)
        {
            if (_data.GetType() == typeof(string))
            {
                var _error = new ErrorResponse((string)_data);
                return new ResultData(_error, false);
            }
            else if (_data.GetType() == typeof(List<string>))
            {
                var _error = new ErrorResponse((List<string>)_data);
                return new ResultData(_error, false);
            }
            return new ResultData(_data, false);
        }

        public static List<string> ToErrorList(this IList<FluentValidation.Results.ValidationFailure> list)
        {
            var _result = new List<string>();
            foreach (var item in list)
                _result.Add(item.ErrorMessage);
            return _result;
        }

        public static T GetAttribute<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static IActionResult Convert(ResultData _resultData)
        {
            if (_resultData.Success)
                return new ObjectResult(_resultData) { StatusCode = (int)HttpStatusCode.OK };

            return new BadRequestObjectResult(_resultData);
        }

        public static string Description(this Enum valorEnum)
        {
            return valorEnum.GetAttribute<DescriptionAttribute>().Description;
        }
    }
}
