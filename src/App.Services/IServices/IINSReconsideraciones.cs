using App.Services.Services;
using App.ViewModels.INSReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IINSReconsideraciones
    {
        Task<getInsertarAtencionTotal> InsertarAtencionTotal(int Id, string user);
    }
}
