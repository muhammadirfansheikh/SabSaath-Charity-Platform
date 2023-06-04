using SabSath.Core.Models;
using SabSath.Core.Utilities;
using SabSath.Data.DataRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Application.Repositiories
{
    public interface IDashboardService
    {
        dynamic DashBoard_Card_List(DashBoard.CardList objData);
        dynamic DashBoard_Card_TotalCounts(DashBoard.CardList objData);
    }

   
    public class DashboardService : IDashboardService
    {
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

        private readonly IDashBoardDataDapperRepository _IDashBoardDataDapperRepository;
        public DashboardService(IDashBoardDataDapperRepository DashBoardDataDapperRepository)
        {
            _IDashBoardDataDapperRepository = DashBoardDataDapperRepository;
        }

        public dynamic DashBoard_Card_List(DashBoard.CardList objData)
        {
            try
            {

                DataSet obj_response = _IDashBoardDataDapperRepository.DashBoard_Card_List(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }


        public dynamic DashBoard_Card_TotalCounts(DashBoard.CardList objData)
        {
            try
            {

                DataSet obj_response = _IDashBoardDataDapperRepository.DashBoard_Card_TotalCounts(objData);
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception e)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ResponseMessages.Exception);
            }
        }


        

    }
}
