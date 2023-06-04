using CoreHtmlToImage;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Core.Utilities
{
    public static class CommonObjects
    {
        public static Dictionary<string, object> GetRepsonse(bool IsSuccess, string ResponseCode, string ResponseMessage, dynamic data = null, string Token = null)
        {
            Dictionary<string, object> objResponse = new Dictionary<string, object>();
            objResponse.Add(ResponseKeys.Response, IsSuccess);
            objResponse.Add(ResponseKeys.ResponseCode, ResponseCode);
            objResponse.Add(ResponseKeys.ResponseMessage, ResponseMessage);
            objResponse.Add(ResponseKeys.Data, data);
            return objResponse;
        }
        public static MessageDate<dynamic> GetRepsonses(bool IsSuccess, string ResponseCode, string ResponseMessage, dynamic data = null, string Token = null)
        {
            MessageDate<dynamic> messageData = new MessageDate<dynamic>();
            messageData.Data = data;
            messageData.Response = IsSuccess;
            messageData.ResponseCodes = ResponseCode;
            messageData.ResponseMessage = ResponseMessage;
            return messageData;
        }
        public static MessageDate<dynamic> GetRepsonsesWithDataSet(bool IsSuccess, string ResponseCode, string ResponseMessage, DataSet data = null, string Token = null)
        {
            MessageDate<dynamic> messageData = new MessageDate<dynamic>();
            messageData.DataSet = data;
            messageData.Response = IsSuccess;
            messageData.ResponseCodes = ResponseCode;
            messageData.ResponseMessage = ResponseMessage;
            return messageData;
        }
        public static MessageDate_M<dynamic> GetRepsonses_M(dynamic data = null)
        {
            MessageDate_M<dynamic> messageDataM = new MessageDate_M<dynamic>();
            messageDataM.Data = data;
            return messageDataM;
        }
        public static string CreateRandomPassword(int length = 10)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public static List<Menu> GetMenuList(DataTable dt)
        {
            List<Menu> _ListMenues = new List<Menu>();

            if (dt.Rows.Count > 0)
            {
                List<DataRow> _ParentMenues = dt.AsEnumerable().Where(x => x.Field<int?>("Parent_Id") == 0).ToList();
                foreach (var item in _ParentMenues)
                {
                    _ListMenues.Add(
                          new Menu()
                          {
                              path = item.Field<string>("Menu_URL"),
                              name = item.Field<string>("Menu_Name"),
                              icon = item.Field<string>("IconClass"),
                              Is_Displayed_In_Menu = item.Field<bool>("Is_Displayed_In_Menu"),
                              component = item.Field<string>("Menu_URL").Contains("#") ? item.Field<string>("Menu_URL") : item.Field<string>("Menu_URL").Split('/')[1],
                              layout = "/admin",
                              SubMenus = GetSubMenu(dt, item.Field<int>("MenuId"))
                          }
                       );
                }
            }
            return _ListMenues;
        }
        //private static List<SubMenu> GetSubMenu(DataTable childMenues, int? menuID)
        //{

        //    List<SubMenu> _SubMenu = new List<SubMenu>();


        //    List<DataRow> _ChildMenues = childMenues.AsEnumerable().Where(x => x.Field<string>("Menu_URL") != "#" && x.Field<int?>("Parent_Id") == menuID).ToList();


        //    foreach (var item in _ChildMenues)
        //    {
        //        _SubMenu.Add(
        //              new SubMenu()
        //              {
        //                  path = item.Field<string>("Menu_URL"),
        //                  name = item.Field<string>("Menu_Name"),
        //                  icon = item.Field<string>("IconClass"),
        //                  component = item.Field<string>("Menu_URL").Contains("#") ? item.Field<string>("Menu_URL") : item.Field<string>("Menu_URL").Split('/')[1],
        //                  layout = "/admin"

        //              }
        //           );
        //    }


        //    return _SubMenu;

        //}
        private static List<SubMenu> GetSubMenu(DataTable childMenues, int? menuID)
        {
            List<SubMenu> _SubMenu = new List<SubMenu>();
            //List<DataRow> _ChildMenues = childMenues.AsEnumerable().Where(x => x.Field<string>("Menu_URL") != "#" && x.Field<int?>("Parent_Id") == menuID).ToList();
            List<DataRow> _ChildMenues = childMenues.AsEnumerable().Where(x => x.Field<int?>("Parent_Id") == menuID).ToList();

            foreach (var item in _ChildMenues)
            {
                if (item.Field<string>("Menu_URL").Contains("#"))
                {
                    List<DataRow> _subChildMenues = childMenues.AsEnumerable().Where(x => x.Field<int?>("Parent_Id") == item.Field<int>("MenuId")).ToList();
                    //foreach (var item1 in _subChildMenues)
                    //{
                    _SubMenu.Add(
                       new SubMenu()
                       {
                           path = item.Field<string>("Menu_URL"),
                           name = item.Field<string>("Menu_Name"),
                           icon = item.Field<string>("IconClass"),
                           MenuItemId = item.Field<int>("MenuId"),
                           Is_Displayed_In_Menu = item.Field<bool>("Is_Displayed_In_Menu"),
                           component = item.Field<string>("Menu_URL").Contains("#") ? item.Field<string>("Menu_URL") : item.Field<string>("Menu_URL").Split('/')[1],
                           layout = "/admin",
                           ChildSubMenu = GetChildSubMenu(childMenues, item.Field<int>("MenuId"))
                       }
                  );
                    //}
                }
                else
                {
                    _SubMenu.Add(
                          new SubMenu()
                          {
                              path = item.Field<string>("Menu_URL"),
                              name = item.Field<string>("Menu_Name"),
                              icon = item.Field<string>("IconClass"),
                              Is_Displayed_In_Menu = item.Field<bool>("Is_Displayed_In_Menu"),
                              component = item.Field<string>("Menu_URL").Contains("#") ? item.Field<string>("Menu_URL") : item.Field<string>("Menu_URL").Split('/')[1],
                              layout = "/admin"
                          }
                       );
                }
            }
            return _SubMenu;
        }
        private static List<ChildSubMenu> GetChildSubMenu(DataTable childMenues, int menuID)
        {
            List<ChildSubMenu> _ChildSubMenu = new List<ChildSubMenu>();
            List<DataRow> _ChildMenues = childMenues.AsEnumerable().Where(x => x.Field<int?>("Parent_Id") == menuID).ToList();

            foreach (var item in _ChildMenues)
            {
                _ChildSubMenu.Add(
                      new ChildSubMenu()
                      {
                          path = item.Field<string>("Menu_URL"),
                          name = item.Field<string>("Menu_Name"),
                          icon = item.Field<string>("IconClass"),
                          SubMenuItemId = menuID,
                          Is_Displayed_In_Menu = item.Field<bool>("Is_Displayed_In_Menu"),
                          component = item.Field<string>("Menu_URL").Contains("#") ? item.Field<string>("Menu_URL") : item.Field<string>("Menu_URL").Split('/')[1],
                          layout = "/admin"
                      }
                   );
            }
            return _ChildSubMenu;
        }
        public static List<Menu> GetMenus()
        {
            List<Menu> routes = new List<Menu>();



            routes.Add(
                new Menu()
                {
                    path = "/dashboard",
                    name = "Dashboard",
                    icon = "nc-icon nc-bank",
                    component = "Dashboard",
                    layout = "/admin",
                    SubMenus = new List<SubMenu>()
                    {

                    }
                }
                );

            //routes.Add(
            //new Menu()
            //{
            //path = "/Security",
            //name = "Security",
            //icon = "nc-icon nc-caps-small",
            //component = "Security",
            //layout = "/admin",
            //SubMenus = new List<SubMenu>()
            //{
            //    new SubMenu()
            //       {
            //        path = "/Roles",
            //        name = "Roles",
            //        icon = "nc-icon nc-bank",
            //        component = "Roles",
            //        layout = "/admin",
            //       },
            //    new SubMenu()
            //       {
            //        path = "/RolesAccess",
            //        name = "RolesAccess",
            //        icon = "nc-icon nc-bank",
            //        component = "RolesAccess",
            //        layout = "/admin",
            //       },
            //    new SubMenu()
            //       {
            //        path = "/MenuList",
            //        name = "MenuList",
            //        icon = "nc-icon nc-bank",
            //        component = "MenuList",
            //        layout = "/admin",
            //       }
            //}
            //}
            //);
            routes.Add(
            new Menu()
            {
                path = "/Setups",
                name = "Setups",
                icon = "nc-icon nc-caps-small",
                component = "Setups",
                layout = "/admin",
                SubMenus = new List<SubMenu>()
                {
                    new SubMenu()
                       {
                        path = "/SetupUsers",
                        name = "User Profile",
                        icon = "nc-icon nc-bank",
                        component = "SetupUsers",
                        layout = "/admin",
                       },
                    //new SubMenu()
                    //   {
                    //    path = "/Beneficiary",
                    //    name = "Beneficiary",
                    //    icon = "nc-icon nc-bank",
                    //    component = "Beneficiary",
                    //    layout = "/admin",
                    //   },
                      new SubMenu()
                       {
                        path = "/AcademicLevel",
                        name = "Academic Level",
                        icon = "nc-icon nc-bank",
                        component = "AcademicLevel",
                        layout = "/admin",
                       },
                          new SubMenu()
                       {
                        path = "/DocumentType",
                        name = "Document Type",
                        icon = "nc-icon nc-bank",
                        component = "DocumentType",
                        layout = "/admin",
                       },

                               new SubMenu()
                       {
                        path = "/DonationType",
                        name = "Donation Type",
                        icon = "nc-icon nc-bank",
                        component = "DonationType",
                        layout = "/admin",
                       },

                                         new SubMenu()
                       {
                        path = "/HomeApplaince",
                        name = "Home Applaince",
                        icon = "nc-icon nc-bank",
                        component = "HomeApplaince",
                        layout = "/admin",
                       },



                                         new SubMenu()
                       {
                        path = "/Pets",
                        name = "Pets",
                        icon = "nc-icon nc-bank",
                        component = "Pets",
                        layout = "/admin",
                       },


                                         new SubMenu()
                       {
                        path = "/Referrer",
                        name = "Referrer",
                        icon = "nc-icon nc-bank",
                        component = "Referrer",
                        layout = "/admin",
                       },

                                           new SubMenu()
                       {
                        path = "/Country",
                        name = "Country",
                        icon = "nc-icon nc-bank",
                        component = "Country",
                        layout = "/admin",
                       },



                                           new SubMenu()
                       {
                        path = "/City_Village",
                        name = "City / Village",
                        icon = "nc-icon nc-bank",
                        component = "City_Village",
                        layout = "/admin",
                       },new SubMenu()
                       {
                        path = "/Union",
                        name = "Union",
                        icon = "nc-icon nc-bank",
                        component = "Union",
                        layout = "/admin",
                       }
                       ,new SubMenu()
                       {
                        path = "/Bank",
                        name = "Bank",
                        icon = "nc-icon nc-bank",
                        component = "Bank",
                        layout = "/admin",
                       }

                       ,new SubMenu()
                       {
                        path = "/Religion",
                        name = "Religion",
                        icon = "nc-icon nc-bank",
                        component = "Religion",
                        layout = "/admin",
                       }

,new SubMenu()
                       {
                        path = "/Area",
                        name = "Area",
                        icon = "nc-icon nc-bank",
                        component = "Area",
                        layout = "/admin",
                       },


                                           new SubMenu()
                       {
                        path = "/District",
                        name = "District",
                        icon = "nc-icon nc-bank",
                        component = "District",
                        layout = "/admin",
                       },

                    new SubMenu()
                       {
                        path = "/Disability",
                        name = "Disability",
                        icon = "nc-icon nc-bank",
                        component = "Disability",
                        layout = "/admin",
                       },

                                                              new SubMenu()
                       {
                        path = "/Relation",
                        name = "Relation",
                        icon = "nc-icon nc-bank",
                        component = "Relation",
                        layout = "/admin",
                       },

                                          new SubMenu()
                       {
                        path = "/SourceOfDrinkingWater",
                        name = "Source Of Drinking Water",
                        icon = "nc-icon nc-bank",
                        component = "SourceOfDrinkingWater",
                        layout = "/admin",
                       },
                                      new SubMenu()
                       {
                        path = "/Expense",
                        name = "Expense",
                        icon = "nc-icon nc-bank",
                        component = "Expense",
                        layout = "/admin",
                       },
                                    new SubMenu()
                       {
                        path = "/DocumentSubType",
                        name = "Document Sub Type",
                        icon = "nc-icon nc-bank",
                        component = "DocumentSubType",
                        layout = "/admin",
                       },
             new SubMenu()
                       {
                        path = "/Province",
                        name = "Province",
                        icon = "nc-icon nc-bank",
                        component = "Province",
                        layout = "/admin",
                       },
                      new SubMenu()
                       {



                        path = "/AcceptanceOfCharity",
                        name = "Acceptance Of Charity",
                        icon = "nc-icon nc-bank",
                        component = "AcceptanceOfCharity",
                        layout = "/admin",
                       },
                      new SubMenu()
                       {



                        path= "/AssetType",
    name= "Asset Type",
    icon= "nc-icon nc-single-02",
    component= "AssetType",
    layout= "/admin"
                       },
                    new SubMenu()
                       {
                        path = "/Category",
                        name = "Category",
                        icon = "nc-icon nc-bank",
                        component = "Category",
                        layout = "/admin",
                       },
                    new SubMenu()
                       {
                        path = "/Diseases",
                        name = "Diseases",
                        icon = "nc-icon nc-bank",
                        component = "Diseases",
                        layout = "/admin",
                       },


                    new SubMenu()
                       {
                        path = "/Company",
                        name = "Company",
                        icon = "nc-icon nc-bank",
                        component = "Company",
                        layout = "/admin",
                       },
                    new SubMenu()
                       {
                        path = "/CompanyFamily",
                        name = "CompanyFamily",
                        icon = "nc-icon nc-bank",
                        component = "CompanyFamily",
                        layout = "/admin",
                       },
                    //new SubMenu()
                    //   {
                    //    path = "/CompanyLocation",
                    //    name = "CompanyLocation",
                    //    icon = "nc-icon nc-bank",
                    //    component = "CompanyLocation",
                    //    layout = "/admin",
                    //   },
                    new SubMenu()
                       {
                        path = "/Frequency",
                        name = "Frequency",
                        icon = "nc-icon nc-bank",
                        component = "Frequency",
                        layout = "/admin",
                       },
                    new SubMenu()
                       {
                        path = "/FundCategory",
                        name = "FundCategory",
                        icon = "nc-icon nc-bank",
                        component = "FundCategory",
                        layout = "/admin",
                       },

                    //new SubMenu()
                    //   {
                    //    path = "/Fund_Sub_Category",
                    //    name = "Fund Sub Category",
                    //    icon = "nc-icon nc-bank",
                    //    component = "Fund_Sub_Category",
                    //    layout = "/admin",
                    //   },
                    new SubMenu()
                       {
                        path = "/PaymentType",
                        name = "PaymentType",
                        icon = "nc-icon nc-bank",
                        component = "PaymentType",
                        layout = "/admin",
                       },
                }
            }
            );
            routes.Add(
            new Menu()
            {
                path = "/ApplicantListing",
                name = "Applicant List",
                icon = "nc-icon nc-caps-small",
                component = "ApplicantList_New",
                layout = "/admin",
                SubMenus = new List<SubMenu>()
                {

                }
            }
            );


            routes.Add(
           new Menu()
           {
               path = "/Donor",
               name = "Donor",
               icon = "nc-icon nc-caps-small",
               component = "Donor",
               layout = "/admin",
               SubMenus = new List<SubMenu>()
               {

               }
           }
           );
            //routes.Add(
            //new Menu()
            //{
            //    path = "/JobList",
            //    name = "Job List",
            //    icon = "nc-icon nc-caps-small",
            //    component = "JobList",
            //    layout = "/admin",
            //    SubMenus = new List<SubMenu>()
            //    {

            //    }
            //}
            //);
            routes.Add(
            new Menu()
            {
                path = "/CounselingList",
                name = "Counseling List",
                icon = "nc-icon nc-bank",
                component = "CounselingList",
                layout = "/admin",
                SubMenus = new List<SubMenu>()
                {

                }
            }
       );

            routes.Add(
      new Menu()
      {
          path = "/MarketingList",
          name = "Marketing List",
          icon = "nc-icon nc-bank",
          component = "MarketingList",
          layout = "/admin",
          SubMenus = new List<SubMenu>()
          {

          }
      }
 );

            return routes;
        }
        public static List<ParentMenu> GetMenusRolesAccess()
        {
            List<Features> features = new List<Features>();
            features.Add(
           new Features()
           {
               value = 1,
               label = "View"
           });
            List<Features> featuresUser = new List<Features>();
            featuresUser.Add(
           new Features()
           {
               value = 1,
               label = "View"
           });
            featuresUser.Add(
           new Features()
           {
               value = 2,
               label = "Add"
           });

            List<ChildMenu> objChildMenu = new List<ChildMenu>();
            objChildMenu.Add(
               new ChildMenu()
               {
                   value = 1,
                   label = "User",
                   children = featuresUser
               }
           );

            List<ParentMenu> parentMenus = new List<ParentMenu>();
            parentMenus.Add(
               new ParentMenu()
               {
                   value = 1,
                   label = "Dashboard",
                   ParentFeature = features
               }
            );
            parentMenus.Add(
               new ParentMenu()
               {
                   value = 1,
                   label = "Setup",
                   ParentFeature = null,
                   children = objChildMenu
               }
            );
            return parentMenus;
        }
        public static string ConvertHtmlToImage(string _html, string _saveFilePath, string _fileName = "", string _transactionId = "")
        {

            string _FileName = DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_" + _transactionId + "_" + _fileName.Trim() + ".png";

            var converter = new HtmlConverter();
            var html = _html;
            var bytes = converter.FromHtmlString(html);
            File.WriteAllBytes(_saveFilePath + _FileName, bytes);
            return _FileName;
        }
        public static dynamic SendMail(string to, string subject, string msg, string cc, string Attachment)
        {
            MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();

            try
            {

                if (string.IsNullOrEmpty(to) == false)
                {
                    if (GenericConstants._SenderEmailSMTP != "" && GenericConstants._SenderEmail != "" && GenericConstants._SenderEmailPort != "")
                    {


                        MailMessage message = new MailMessage();
                        string[] addresses = to.Split(';');
                        foreach (string address in addresses)
                        {
                            if (!string.IsNullOrEmpty(address))
                            {
                                message.To.Add(new MailAddress(address));
                            }
                        }
                        if (!string.IsNullOrEmpty(cc))
                        {
                            string[] cc_address = cc.Split(';');
                            if (cc_address != null)
                            {
                                foreach (string address in cc_address)
                                {
                                    if (!string.IsNullOrEmpty(address))
                                    {
                                        message.CC.Add(new MailAddress(address));
                                    }
                                }
                            }

                        }
                        //if (!string.IsNullOrEmpty(BCC))
                        //{
                        //    string[] BCC_address = BCC.Split(';');
                        //    if (BCC_address != null)
                        //    {
                        //        foreach (string address in BCC_address)
                        //        {
                        //            if (!string.IsNullOrEmpty(address))
                        //            {
                        //                message.Bcc.Add(new MailAddress(address));
                        //            }
                        //        }
                        //    }
                        //}

                        if (!string.IsNullOrEmpty(Attachment))
                        {
                            string[] Attachment_ = Attachment.Split(';');
                            if (Attachment_ != null)
                            {
                                foreach (string file in Attachment_)
                                {
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        if (File.Exists(file))
                                        {
                                            System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(file);
                                            message.Attachments.Add(attach);
                                        }
                                    }
                                }
                            }
                        }

                        message.From = new MailAddress(GenericConstants._SenderEmail, "Sab Saath");
                        message.Subject = subject;
                        message.Body = msg;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient();
                        client.Port = Convert.ToInt32(GenericConstants._SenderEmailPort);
                        client.Host = GenericConstants._SenderEmailSMTP;
                        System.Net.NetworkCredential objNetworkCredential = new System.Net.NetworkCredential(GenericConstants._SenderEmail, GenericConstants._SenderEmailPassword);
                        client.EnableSsl = Convert.ToBoolean(GenericConstants._SenderEmailSsl);
                        client.UseDefaultCredentials = false;
                        client.Credentials = objNetworkCredential;

                        client.Send(message);
                        return responseDetail = CommonObjects.GetRepsonses(true, ResponseCodes.Success, ResponseMessages.Success, "Email Send Successfully");
                        // WriteFile("Success - ", "", EmailsAddress);

                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email Could Not Send");
                    }
                }
                else
                {

                    responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Failed To Email is Missing");

                }
            }
            catch (SmtpFailedRecipientException ex)
            {
                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");

            }
            catch (SmtpException ex)
            {
                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");
            }
            catch (Exception ex)
            {
                responseDetail = CommonObjects.GetRepsonses(false, ResponseCodes.Success, ResponseMessages.Success, "Email failed");
            }
            return responseDetail;
        }
    }
}
