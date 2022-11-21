using App.ViewModels.RptReconsideraciones;
using App.ViewModels.SELReconsideraciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.IServices
{
    public interface IRptReconsideraciones
    {
        //Task<IEnumerable<GetRptAtenciones>> RptAtenciones(SetRptAtenciones model);
        Task<DataTable> RptAtenciones(SetRptAtenciones model);
    }
}
