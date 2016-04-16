﻿using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssetManagement.DAL
{
    public class AssetDetailsDAL
    {
        public List<string> getStateDetails()
        {
            List<string> list = new List<string>();
            list.Add("Karnataka");

            return list;
        }


        public List<string> getDivisionDetails()
        {
            List<string> list = new List<string>();
            list.Add("Mysuru");

            return list;
        }

        public List<string> getDistrictDetails()
        {
            List<string> list = new List<string>();
            //list.Add("Chamarajanagara");
            //list.Add("Chikkamagaluru");
            //list.Add("Dakshina Kannada");
            //list.Add("Hassan");
            //list.Add("Kodagu");
            list.Add("Mysuru");
            //list.Add("Udupi");

            return list;
        }

        public List<string> getTalukDetails()
        {
            List<string> list = new List<string>();
            //list.Add("Hunsur");
            //list.Add("Heggadadevanakote");
            //list.Add("Krishnaraja Nagara");
            list.Add("Mysuru");
            //list.Add("Nanjangud");
            //list.Add("Piriyapatna");
            //list.Add("Tirumakudala Narasipura");

            return list;
        }


        public List<string> getMPConstituency()
        {
            List<string> list = new List<string>();
            list.Add("Mysuru");

            return list;
        }


        public List<string> getMLAConstituency()
        {
            List<string> list = new List<string>();
            list.Add("Chamaraja");
            list.Add("Krishnaraja");
            list.Add("Narasimharaja");
            list.Add("Chamundeshwari");
            list.Add("Varuna");
            list.Add("Hunsur");
            list.Add("Piriyapatna");
            list.Add("Krishnarajanagara");
            list.Add("Heggadadevanakote");
            list.Add("Nanjangud");
            list.Add("Tirumakudalu Narasipura");

            return list;
        }

        public List<string> getTalukPanchayath()
        {
            List<string> list = new List<string>();
            list.Add("Mysuru");
            list.Add("Nanjangud");
            list.Add("Heggadadevanakote");
            list.Add("Hunsur");
            list.Add("Piriyapatna");
            list.Add("Krishnaraja Nagara");
            list.Add("Tirumakudala Narsipur");

            return list;
        }





        public List<string> getAssetType()
        {
            List<string> list = new List<string>();
            list.Add("Agricultural");
            list.Add("Shop");
            list.Add("Plot");
            list.Add("Building");
            list.Add("House");
            list.Add("Mosque");
            list.Add("Madrasa");
            list.Add("Madrasa");
            list.Add("School");
            list.Add("Darul uloom");
            list.Add("Lidgah");
            list.Add("Musafirkhana");
            list.Add("Khankaha");
            list.Add("Imambara");

            return list;
        }

        public List<string> getAssetStatus()
        {
            List<string> list = new List<string>();
            list.Add("Alienated");
            list.Add("Enroached");
            list.Add("Litigated");
            list.Add("Non-encumbered");
            list.Add("Unknown");
            list.Add("Others");

            return list;
        }

        public List<string> getInstitutionType()
        {
            List<string> list = new List<string>();
            list.Add("Registered");
            list.Add("Un-registered");

            return list;
        }

        public List<string> getClassification()
        {
            List<string> list = new List<string>();
            list.Add("Sunni");
            list.Add("Shia");

            return list;
        }

        public List<string> getManagementType()
        {
            List<string> list = new List<string>();
            list.Add("Managing Committee");
            list.Add("Adhoc Committee");

            return list;
        }

        public List<string> getMainAssetName()
        {
            List<string> list = new List<string>();
            list.Add("XYZ");
            list.Add("ABC");

            return list;
        }

        public bool saveInstitutionInformation(AssetViewModels model)
        {
            try
            {
                SqlCommand cmd;
                String insert_sql;
                int numRowsAffected = -1;

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstitutionConnection"].ToString()))
                {
                    con.Open();
                    insert_sql = " INSERT INTO Institution (institutionId,institutionType,state,division,taluk,district,mpConstituency,mlaConstituency,urban,rural,municipalWardNo,talukPanchayat,gramaPanchayat,village,latitude,longitude,advisorySocietyName,advisoryApprovalNumber,advisoryRegNumber,advisoryRegDate,advisoryExpDate,institutionName,assetName,address,assetType,assetStatus,gnNumber,gnDate,crNumber,crDate,classificationType,surveyNo,khathaNo,municipalNo,north,east,south,west,estimatedValue,litigationManagement,litigationAsset,managementType,managementSocietyName,managementApprovalNumber,managementRegNumber,managementRegDate,managementExpDate,total,northToSouth,eastToWest,propertyID,courtJudgementOrder,waqfID,wamsiCode) ";
                    insert_sql += " VALUES(@institutionId,@institutionType,@state,@division,@taluk,@district,@mpConstituency,@mlaConstituency,@urban,@rural,@municipalWardNo,@talukPanchayat,@gramaPanchayat,@village,@latitude,@longitude,@advisorySocietyName,@advisoryApprovalNumber,@advisoryRegNumber, @advisoryRegDate, @advisoryExpDate, @institutionName, @assetName,@address, @assetType, @assetStatus, @gnNumber, @gnDate, @crNumber, @crDate, @classificationType, @surveyNo, @khathaNo, @municipalNo, @north, @east, @south, @west, @estimatedValue, @litigationManagement, @litigationAsset, @managementType, @managementSocietyName, @managementApprovalNumber, @managementRegNumber, @managementRegDate, @managementExpDate,@total,@northToSouth,@eastToWest,@propertyID,@courtJudgementOrder,@waqfID,@wamsiCode) ";

                    cmd = new SqlCommand(insert_sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@institutionId", SqlDbType.VarChar);
                    cmd.Parameters["@institutionId"].Value = "KAMYS001";

                    cmd.Parameters.Add("@institutionType", SqlDbType.VarChar);
                    cmd.Parameters["@institutionType"].Value = "MainAsset";

                    cmd.Parameters.Add("@state", SqlDbType.VarChar);
                    if (model.selectedState == null || model.selectedState == "")
                    {
                        cmd.Parameters["@state"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@state"].Value = model.selectedState;
                    }

                    cmd.Parameters.Add("@division", SqlDbType.VarChar);
                    if (model.selectedDivision == null || model.selectedDivision == "")
                    {
                        cmd.Parameters["@division"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@division"].Value = model.selectedDivision;
                    }


                    cmd.Parameters.Add("@taluk", SqlDbType.VarChar);
                    if (model.selectedTaluk == null || model.selectedTaluk == "")
                    {
                        cmd.Parameters["@taluk"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@taluk"].Value = model.selectedTaluk;
                    }



                    cmd.Parameters.Add("@district", SqlDbType.VarChar);
                    if (model.selectedDistrict == null || model.selectedDistrict == "")
                    {
                        cmd.Parameters["@district"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@district"].Value = model.selectedDistrict;
                    }



                    cmd.Parameters.Add("@mpConstituency", SqlDbType.VarChar);
                    if (model.selectedMPConstituency == null || model.selectedMPConstituency == "")
                    {
                        cmd.Parameters["@mpConstituency"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@mpConstituency"].Value = model.selectedMPConstituency;
                    }


                    cmd.Parameters.Add("@mlaConstituency", SqlDbType.VarChar);
                    if (model.selectedMLAConstituency == null || model.selectedMLAConstituency == "")
                    {
                        cmd.Parameters["@mlaConstituency"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@mlaConstituency"].Value = model.selectedMLAConstituency;
                    }


                    cmd.Parameters.Add("@urban", SqlDbType.VarChar);
                    if (model.urban == null || model.urban == "")
                    {
                        cmd.Parameters["@urban"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@urban"].Value = model.urban;
                    }


                    cmd.Parameters.Add("@rural", SqlDbType.VarChar);
                    if (model.rural == null || model.rural == "")
                    {
                        cmd.Parameters["@rural"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@rural"].Value = model.rural;   //10

                    }

                    cmd.Parameters.Add("@municipalWardNo", SqlDbType.VarChar);
                    if (model.selectedMunicipalWardNo == null || model.selectedMunicipalWardNo == "")
                    {
                        cmd.Parameters["@municipalWardNo"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@municipalWardNo"].Value = model.selectedMunicipalWardNo;
                    }

                    cmd.Parameters.Add("@talukPanchayat", SqlDbType.VarChar);
                    if (model.selectedTalukPanchayat == null || model.selectedTalukPanchayat == "")
                    {
                        cmd.Parameters["@talukPanchayat"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@talukPanchayat"].Value = model.selectedTalukPanchayat;
                    }


                    cmd.Parameters.Add("@gramaPanchayat", SqlDbType.VarChar);
                    if (model.selectedGramaPanchayat == null || model.selectedGramaPanchayat == "")
                    {
                        cmd.Parameters["@gramaPanchayat"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@gramaPanchayat"].Value = model.selectedGramaPanchayat;
                    }



                    cmd.Parameters.Add("@village", SqlDbType.VarChar);
                    if (model.selectedVillage == null || model.selectedVillage == "")
                    {
                        cmd.Parameters["@village"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@village"].Value = model.selectedVillage;
                    }


                    cmd.Parameters.Add("@latitude", SqlDbType.Decimal);
                    if (model.latitude.Equals(null))
                    {
                        cmd.Parameters["@latitude"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@latitude"].Value = model.latitude;
                    }


                    cmd.Parameters.Add("@longitude", SqlDbType.Decimal);
                    if (model.longitude.Equals(null))
                    {
                        cmd.Parameters["@longitude"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@longitude"].Value = model.longitude;
                    }


                    cmd.Parameters.Add("@advisorySocietyName", SqlDbType.VarChar);
                    if (model.advisorySocietyName == null || model.advisorySocietyName == "")
                    {
                        cmd.Parameters["@advisorySocietyName"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@advisorySocietyName"].Value = model.advisorySocietyName;
                    }


                    cmd.Parameters.Add("@advisoryApprovalNumber", SqlDbType.VarChar);
                    if (model.advisoryApprovalNumber == null || model.advisoryApprovalNumber == "")
                    {
                        cmd.Parameters["@advisoryApprovalNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@advisoryApprovalNumber"].Value = model.advisoryApprovalNumber;
                    }


                    cmd.Parameters.Add("@advisoryRegNumber", SqlDbType.VarChar);
                    if (model.advisoryRegNumber == null || model.advisoryRegNumber == "")
                    {
                        cmd.Parameters["@advisoryRegNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@advisoryRegNumber"].Value = model.advisoryRegNumber;
                    }


                    cmd.Parameters.Add("@advisoryRegDate", SqlDbType.Date);
                    if (model.advisoryRegDate == null)
                    {
                        cmd.Parameters["@advisoryRegDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@advisoryRegDate"].Value = model.advisoryRegDate;
                    }
                    //20

                    cmd.Parameters.Add("@advisoryExpDate", SqlDbType.Date);
                    if (model.advisoryExpDate == null)
                    {
                        cmd.Parameters["@advisoryExpDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@advisoryExpDate"].Value = model.advisoryExpDate;
                    }


                    cmd.Parameters.Add("@institutionName", SqlDbType.VarChar);
                    if (model.institutionName == null || model.institutionName == "")
                    {
                        cmd.Parameters["@institutionName"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@institutionName"].Value = model.institutionName;
                    }


                    cmd.Parameters.Add("@assetName", SqlDbType.VarChar);
                    if (model.assetName == null || model.assetName == "")
                    {
                        cmd.Parameters["@assetName"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@assetName"].Value = model.assetName;
                    }


                    cmd.Parameters.Add("@address", SqlDbType.VarChar);
                    if (model.address == null || model.address == "")
                    {
                        cmd.Parameters["@address"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@address"].Value = model.address;
                    }


                    cmd.Parameters.Add("@assetType", SqlDbType.VarChar);
                    if (model.selectedAssetType == null || model.selectedAssetType == "")
                    {
                        cmd.Parameters["@assetType"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@assetType"].Value = model.selectedAssetType;
                    }

                    cmd.Parameters.Add("@assetStatus", SqlDbType.VarChar);
                    if (model.selectedAssetStatus == null || model.selectedAssetStatus == "")
                    {
                        cmd.Parameters["@assetStatus"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@assetStatus"].Value = model.selectedAssetStatus;
                    }


                    cmd.Parameters.Add("@gnNumber", SqlDbType.VarChar);
                    if (model.gnNumber == null || model.gnNumber == "")
                    {
                        cmd.Parameters["@gnNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@gnNumber"].Value = model.gnNumber;
                    }


                    cmd.Parameters.Add("@gnDate", SqlDbType.Date);
                    if (model.gnDate == null)
                    {
                        cmd.Parameters["@gnDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@gnDate"].Value = model.gnDate;
                    }


                    cmd.Parameters.Add("@crNumber", SqlDbType.VarChar);
                    if (model.crNumber == null || model.crNumber == "")
                    {
                        cmd.Parameters["@crNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@crNumber"].Value = model.crNumber;
                    }


                    cmd.Parameters.Add("@crDate", SqlDbType.Date);
                    if (model.crDate == null)
                    {
                        cmd.Parameters["@crDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@crDate"].Value = model.crDate;
                    }


                    cmd.Parameters.Add("@classificationType", SqlDbType.VarChar);
                    if (model.selectedClassificationType == null || model.selectedClassificationType == "")
                    {
                        cmd.Parameters["@classificationType"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@classificationType"].Value = model.selectedClassificationType;
                    }
                    //30

                    cmd.Parameters.Add("@surveyNo", SqlDbType.VarChar);
                    if (model.surveyNo == null || model.surveyNo == "")
                    {
                        cmd.Parameters["@surveyNo"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@surveyNo"].Value = model.surveyNo;
                    }


                    cmd.Parameters.Add("@khathaNo", SqlDbType.VarChar);
                    if (model.khathaNo == null || model.khathaNo == "")
                    {
                        cmd.Parameters["@khathaNo"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@khathaNo"].Value = model.khathaNo;
                    }


                    cmd.Parameters.Add("@municipalNo", SqlDbType.VarChar);
                    if (model.municipalNo == null || model.municipalNo == "")
                    {
                        cmd.Parameters["@municipalNo"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@municipalNo"].Value = model.municipalNo;
                    }


                    cmd.Parameters.Add("@north", SqlDbType.VarChar);
                    if (model.north == null || model.north == "")
                    {
                        cmd.Parameters["@north"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@north"].Value = model.north;
                    }


                    cmd.Parameters.Add("@east", SqlDbType.VarChar);
                    if (model.east == null || model.east == "")
                    {
                        cmd.Parameters["@east"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@east"].Value = model.east;
                    }


                    cmd.Parameters.Add("@south", SqlDbType.VarChar);
                    if (model.south == null || model.south == "")
                    {
                        cmd.Parameters["@south"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@south"].Value = model.south;
                    }


                    cmd.Parameters.Add("@west", SqlDbType.VarChar);
                    if (model.west == null || model.west == "")
                    {
                        cmd.Parameters["@west"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@west"].Value = model.west;
                    }


                    cmd.Parameters.Add("@estimatedValue", SqlDbType.VarChar);
                    if (model.estimatedValue == null || model.estimatedValue == "")
                    {
                        cmd.Parameters["@estimatedValue"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@estimatedValue"].Value = model.estimatedValue;
                    }


                    cmd.Parameters.Add("@litigationManagement", SqlDbType.VarChar);
                    if (model.litigationManagement == null || model.litigationManagement == "")
                    {
                        cmd.Parameters["@litigationManagement"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@litigationManagement"].Value = model.litigationManagement;
                    }


                    cmd.Parameters.Add("@litigationAsset", SqlDbType.VarChar);
                    if (model.litigationAsset == null || model.litigationAsset == "")
                    {
                        cmd.Parameters["@litigationAsset"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@litigationAsset"].Value = model.litigationAsset;
                    }
                    //40

                    cmd.Parameters.Add("@managementType", SqlDbType.VarChar);
                    if (model.selectedManagementType == null || model.selectedManagementType == "")
                    {
                        cmd.Parameters["@managementType"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementType"].Value = model.selectedManagementType;
                    }


                    cmd.Parameters.Add("@managementSocietyName", SqlDbType.VarChar);
                    if (model.managementSocietyName == null || model.managementSocietyName == "")
                    {
                        cmd.Parameters["@managementSocietyName"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementSocietyName"].Value = model.managementSocietyName;
                    }


                    cmd.Parameters.Add("@managementApprovalNumber", SqlDbType.VarChar);
                    if (model.managementApprovalNumber == null || model.managementApprovalNumber == "")
                    {
                        cmd.Parameters["@managementApprovalNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementApprovalNumber"].Value = model.managementApprovalNumber;
                    }


                    cmd.Parameters.Add("@managementRegNumber", SqlDbType.VarChar);
                    if (model.managementRegNumber == null || model.managementRegNumber == "")
                    {
                        cmd.Parameters["@managementRegNumber"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementRegNumber"].Value = model.managementRegNumber;
                    }


                    cmd.Parameters.Add("@managementRegDate", SqlDbType.Date);
                    if (model.managementRegDate == null)
                    {
                        cmd.Parameters["@managementRegDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementRegDate"].Value = model.managementRegDate;
                    }


                    cmd.Parameters.Add("@managementExpDate", SqlDbType.Date);
                    if (model.managementExpDate == null)
                    {
                        cmd.Parameters["@managementExpDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementExpDate"].Value = model.managementExpDate;
                    }

                    cmd.Parameters.Add("@total", SqlDbType.VarChar);
                    if (model.total == null || model.total == "")
                    {
                        cmd.Parameters["@total"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@total"].Value = model.total;
                    }

                    cmd.Parameters.Add("@northToSouth", SqlDbType.VarChar);
                    if (model.northToSouth == null || model.northToSouth == "")
                    {
                        cmd.Parameters["@northToSouth"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@northToSouth"].Value = model.northToSouth;
                    }

                    cmd.Parameters.Add("@eastToWest", SqlDbType.VarChar);
                    if (model.eastToWest == null || model.eastToWest == "")
                    {
                        cmd.Parameters["@eastToWest"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@eastToWest"].Value = model.eastToWest;
                    }

                    cmd.Parameters.Add("@propertyID", SqlDbType.VarChar);
                    if (model.propertyID == null || model.propertyID == "")
                    {
                        cmd.Parameters["@propertyID"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@propertyID"].Value = model.propertyID;
                    }

                    cmd.Parameters.Add("@courtJudgementOrder", SqlDbType.VarChar);
                    if (model.courtJudgementOrder == null || model.courtJudgementOrder == "")
                    {
                        cmd.Parameters["@courtJudgementOrder"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@courtJudgementOrder"].Value = model.courtJudgementOrder;
                    }

                    cmd.Parameters.Add("@waqfID", SqlDbType.VarChar);
                    if (model.waqfID == null || model.waqfID == "")
                    {
                        cmd.Parameters["@waqfID"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@waqfID"].Value = model.waqfID;
                    }

                    cmd.Parameters.Add("@wamsiCode", SqlDbType.VarChar);
                    if (model.wamsiCode == null || model.wamsiCode == "")
                    {
                        cmd.Parameters["@wamsiCode"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@wamsiCode"].Value = model.wamsiCode;
                    }

                    numRowsAffected = cmd.ExecuteNonQuery();
                    if (numRowsAffected < 1)
                    {
                        // Problem inserting this row into DB
                        Exception e = new Exception("Errors encountered while saving Institution details!!!");
                        throw (e);
                    }
                    else
                    {
                       // con.Close();
                        saveAdvisoryCommitteeDetails(con,model);
                        saveManagementCommitteeDetails(con,model);

                        return true;
                    }

                }

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }



        public JArray getListOfAssets()
        {
            String select_sql = null;
            SqlDataReader rdr;
            SqlCommand cmd = null;

            JArray jarray = new JArray();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstitutionConnection"].ToString()))
                {
                    con.Open();
                    select_sql = "select institutionName,assetName from Institution";
                    cmd = new SqlCommand(select_sql, con);
                    cmd.CommandType = CommandType.Text;

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) 
                    {
                        JObject jobj = new JObject();
                        jobj.Add("Institution Name", rdr.GetString(0));
                        jobj.Add("Asset Name", rdr.GetString(1));

                        jarray.Add(jobj);
                    }


                    rdr.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return jarray;
        }

        public AssetViewModels getAssetDetailsForEditFLow(string assetName, AssetViewModels model)
        {
            String select_sql = null;
            SqlDataReader rdr;
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstitutionConnection"].ToString()))
                {
                    con.Open();
                    select_sql = "select institutionId,institutionType,state,division,taluk,district,mpConstituency,mlaConstituency,urban,rural,municipalWardNo,talukPanchayat,gramaPanchayat,village,latitude,longitude,advisorySocietyName,advisoryApprovalNumber,advisoryRegNumber,advisoryRegDate,advisoryExpDate,institutionName,assetName,address,assetType,assetStatus,gnNumber,gnDate,crNumber,crDate,classificationType,surveyNo,khathaNo,municipalNo,north,east,south,west,estimatedValue,litigationManagement,litigationAsset,managementType,managementSocietyName,managementApprovalNumber,managementRegNumber,managementRegDate,managementExpDate,total,northToSouth,eastToWest,propertyID,courtJudgementOrder,waqfID,wamsiCode from Institution where assetName=@assetName";
                    cmd = new SqlCommand(select_sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@assetName", SqlDbType.VarChar);
                    cmd.Parameters["@assetName"].Value = assetName;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(1))
                            model.assetTypeFlow = rdr.GetString(1);
                        else
                            model.assetTypeFlow = null;

                        if (!rdr.IsDBNull(2))
                            model.selectedState = rdr.GetString(2);
                        else
                            model.selectedState = null;

                        if (!rdr.IsDBNull(3))
                            model.selectedDivision = rdr.GetString(3);
                        else
                            model.selectedDivision = null;

                        if (!rdr.IsDBNull(4))
                            model.selectedTaluk = rdr.GetString(4);
                        else
                            model.selectedTaluk = null;

                        if (!rdr.IsDBNull(5))
                            model.selectedDistrict = rdr.GetString(5);
                        else
                            model.selectedDistrict = null;

                        if (!rdr.IsDBNull(6))
                            model.selectedMPConstituency = rdr.GetString(6);
                        else
                            model.selectedMPConstituency = null;

                        if (!rdr.IsDBNull(7))
                            model.selectedMLAConstituency = rdr.GetString(7);
                        else
                            model.selectedMLAConstituency = null;

                        if (!rdr.IsDBNull(8))
                            model.urban = rdr.GetString(8);
                        else
                            model.urban = null;

                        if (!rdr.IsDBNull(9))
                            model.rural = rdr.GetString(9);
                        else
                            model.rural = null;

                        if (!rdr.IsDBNull(10))
                            model.selectedMunicipalWardNo = rdr.GetString(10);
                        else
                            model.selectedMunicipalWardNo = null;

                        if (!rdr.IsDBNull(11))
                            model.selectedTalukPanchayat = rdr.GetString(11);
                        else
                            model.selectedTalukPanchayat = null;

                        if (!rdr.IsDBNull(12))
                            model.selectedGramaPanchayat = rdr.GetString(12);
                        else
                            model.selectedGramaPanchayat = null;

                        if (!rdr.IsDBNull(13))
                            model.selectedVillage = rdr.GetString(13);
                        else
                            model.selectedVillage = null;

                        if (!rdr.IsDBNull(14))
                            model.latitude = rdr.GetDouble(14);


                        if (!rdr.IsDBNull(15))
                            model.longitude = rdr.GetDouble(15);


                        if (!rdr.IsDBNull(16))
                            model.advisorySocietyName = rdr.GetString(16);
                        else
                            model.advisorySocietyName = null;

                        if (!rdr.IsDBNull(17))
                            model.advisoryApprovalNumber = rdr.GetString(17);
                        else
                            model.advisoryApprovalNumber = null;

                        if (!rdr.IsDBNull(18))
                            model.advisoryRegNumber = rdr.GetString(18);
                        else
                            model.advisoryRegNumber = null;

                        if (!rdr.IsDBNull(19))
                            model.advisoryRegDate = rdr.GetDateTime(19);

                        if (!rdr.IsDBNull(20))
                            model.advisoryExpDate = rdr.GetDateTime(20);

                        if (!rdr.IsDBNull(21))
                            model.institutionName = rdr.GetString(21);
                        else
                            model.institutionName = null;

                        if (!rdr.IsDBNull(22))
                            model.assetName = rdr.GetString(22);
                        else
                            model.assetName = null;

                        if (!rdr.IsDBNull(23))
                            model.address = rdr.GetString(23);
                        else
                            model.address = null;

                        if (!rdr.IsDBNull(24))
                            model.selectedAssetType = rdr.GetString(24);
                        else
                            model.selectedAssetType = null;

                        if (!rdr.IsDBNull(25))
                            model.selectedAssetStatus = rdr.GetString(25);
                        else
                            model.selectedAssetStatus = null;

                        if (!rdr.IsDBNull(26))
                            model.gnNumber = rdr.GetString(26);
                        else
                            model.gnNumber = null;

                        if (!rdr.IsDBNull(27))
                            model.gnDate = rdr.GetDateTime(27);

                        if (!rdr.IsDBNull(28))
                            model.crNumber = rdr.GetString(28);
                        else
                            model.crNumber = null;

                        if (!rdr.IsDBNull(29))
                            model.crDate = rdr.GetDateTime(29);

                        if (!rdr.IsDBNull(30))
                            model.selectedClassificationType = rdr.GetString(30);
                        else
                            model.selectedClassificationType = null;

                        if (!rdr.IsDBNull(31))
                            model.surveyNo = rdr.GetString(31);
                        else
                            model.surveyNo = null;

                        if (!rdr.IsDBNull(32))
                            model.khathaNo = rdr.GetString(32);
                        else
                            model.khathaNo = null;

                        if (!rdr.IsDBNull(33))
                            model.municipalNo = rdr.GetString(33);
                        else
                            model.municipalNo = null;

                        if (!rdr.IsDBNull(34))
                            model.north = rdr.GetString(34);
                        else
                            model.north = null;

                        if (!rdr.IsDBNull(35))
                            model.east = rdr.GetString(35);
                        else
                            model.east = null;

                        if (!rdr.IsDBNull(36))
                            model.south = rdr.GetString(36);
                        else
                            model.south = null;

                        if (!rdr.IsDBNull(37))
                            model.west = rdr.GetString(37);
                        else
                            model.west = null;

                        if (!rdr.IsDBNull(38))
                            model.estimatedValue = rdr.GetString(38);
                        else
                            model.estimatedValue = null;

                        if (!rdr.IsDBNull(39))
                            model.litigationManagement = rdr.GetString(39);
                        else
                            model.litigationManagement = null;

                        if (!rdr.IsDBNull(40))
                            model.litigationAsset = rdr.GetString(40);
                        else
                            model.litigationAsset = null;

                        if (!rdr.IsDBNull(41))
                            model.selectedManagementType = rdr.GetString(41);
                        else
                            model.selectedManagementType = null;

                        if (!rdr.IsDBNull(42))
                            model.managementSocietyName = rdr.GetString(42);
                        else
                            model.managementSocietyName = null;

                        if (!rdr.IsDBNull(43))
                            model.managementApprovalNumber = rdr.GetString(43);
                        else
                            model.managementApprovalNumber = null;

                        if (!rdr.IsDBNull(44))
                            model.managementRegNumber = rdr.GetString(44);
                        else
                            model.managementRegNumber = null;

                        if (!rdr.IsDBNull(45))
                            model.managementRegDate = rdr.GetDateTime(45);

                        if (!rdr.IsDBNull(46))
                            model.managementExpDate = rdr.GetDateTime(46);

                        if (!rdr.IsDBNull(47))
                            model.total = rdr.GetString(47);
                        else
                            model.total = null;

                        if (!rdr.IsDBNull(48))
                            model.northToSouth = rdr.GetString(48);
                        else
                            model.northToSouth = null;

                        if (!rdr.IsDBNull(49))
                            model.eastToWest = rdr.GetString(49);
                        else
                            model.eastToWest = null;

                        if (!rdr.IsDBNull(50))
                            model.propertyID = rdr.GetString(50);
                        else
                            model.propertyID = null;

                        if (!rdr.IsDBNull(51))
                            model.courtJudgementOrder = rdr.GetString(51);
                        else
                            model.courtJudgementOrder = null;

                        if (!rdr.IsDBNull(52))
                            model.waqfID = rdr.GetString(52);
                        else
                            model.waqfID = null;

                        if (!rdr.IsDBNull(53))
                            model.wamsiCode = rdr.GetString(53);
                        else
                            model.wamsiCode = null;

                    }

                    rdr.Close();

                    getManagementDetailsFromDB("KAMYS001",con, model);
                    getDistrictAdvisoryDetailsFromDB("KAMYS001", con, model);

                    return model;
                }
            }

            catch (Exception)
            {

                throw;
            }
                
        }

        public void removeInstitutionFromDB(string assetName)
        {
            String select_sql = null;
            SqlDataReader rdr;
            SqlCommand cmd = null;

            
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InstitutionConnection"].ToString()))
                {
                    con.Open();
                    select_sql = "delete from Institution where assetName=@assetName";
                    cmd = new SqlCommand(select_sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@assetName", SqlDbType.VarChar);
                    cmd.Parameters["@assetName"].Value = assetName;

                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void saveManagementCommitteeDetails(SqlConnection con, AssetViewModels model)
        {
            SqlCommand cmd;
            String insert_sql;
            int numRowsAffected = -1;

            model.managementDetails = (List<CommitteeDetails>)HttpContext.Current.Session["managementLst"];

            if (model.managementDetails != null)
            {
                
                insert_sql = " INSERT INTO ManagementCommitteeDetails (instituionId, designation, name, mobile, emailID, appointmentType, appointmentDate, tenure,managementCommittee) ";
                insert_sql += " VALUES(@institutionId, @designation, @name, @mobile, @emailID, @appointmentType, @appointmentDate, @tenure, @managementCommittee)";

                foreach (var i in model.managementDetails)
                {
                    cmd = new SqlCommand(insert_sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@institutionId", SqlDbType.VarChar);
                    cmd.Parameters["@institutionId"].Value = "KAMYS001";

                    cmd.Parameters.Add("@designation", SqlDbType.VarChar);
                    if (i.designation == null || i.designation == "")
                    {
                        cmd.Parameters["@designation"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@designation"].Value = i.designation;
                    }

                    cmd.Parameters.Add("@name", SqlDbType.VarChar);
                    if (i.name == null || i.name == "")
                    {
                        cmd.Parameters["@name"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@name"].Value = i.name;
                    }

                    cmd.Parameters.Add("@mobile", SqlDbType.Int);
                    if (i.mobile.Equals(null))
                    {
                        cmd.Parameters["@mobile"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@mobile"].Value = i.mobile;
                    }

                    cmd.Parameters.Add("@emailID", SqlDbType.VarChar);
                    if (i.emailID == null || i.emailID == "")
                    {
                        cmd.Parameters["@emailID"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@emailID"].Value = i.emailID;
                    }

                    cmd.Parameters.Add("@appointmentType", SqlDbType.VarChar);
                    if (i.appointmentType == null || i.appointmentType == "")
                    {
                        cmd.Parameters["@appointmentType"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@appointmentType"].Value = i.appointmentType;
                    }

                    cmd.Parameters.Add("@appointmentDate", SqlDbType.VarChar);
                    if (i.appointmentDate == null || i.appointmentDate == "")
                    {
                        cmd.Parameters["@appointmentDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@appointmentDate"].Value = i.appointmentType;
                    }

                    cmd.Parameters.Add("@tenure", SqlDbType.VarChar);
                    if (i.tenure == null || i.tenure == "")
                    {
                        cmd.Parameters["@tenure"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@tenure"].Value = i.tenure;
                    }

                    cmd.Parameters.Add("@managementCommittee", SqlDbType.VarChar);
                    if (model.selectedManagementType == null || model.selectedManagementType == "")
                    {
                        cmd.Parameters["@managementCommittee"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@managementCommittee"].Value = model.selectedManagementType;

                    }

                    numRowsAffected = cmd.ExecuteNonQuery();
                    if (numRowsAffected < 1)
                    {
                        // Problem inserting this row into DB
                        Exception e = new Exception("Errors encountered while saving Institution details!!!");
                        throw (e);
                    }

                }

            }

        }


        public void saveAdvisoryCommitteeDetails(SqlConnection con, AssetViewModels model)
        {
            SqlCommand cmd;
            String insert_sql;
            int numRowsAffected = -1;

            model.advisoryDetails = (List<CommitteeDetails>)HttpContext.Current.Session["advisoryLst"];
            if (model.advisoryDetails != null)
            {

                insert_sql = " INSERT INTO AdvisoryCommitteeDetails (instituionId, designation, name, mobile, emailID, appointmentType, appointmentDate, tenure) ";
                insert_sql += " VALUES(@institutionId, @designation, @name, @mobile, @emailID, @appointmentType, @appointmentDate, @tenure)";

                foreach (var i in model.advisoryDetails)
                {
                    cmd = new SqlCommand(insert_sql, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@institutionId", SqlDbType.VarChar));
                    cmd.Parameters["@institutionId"].Value = "KAMYS001";

                    cmd.Parameters.Add("@designation", SqlDbType.VarChar);
                    if (i.designation == null || i.designation == "")
                    {
                        cmd.Parameters["@designation"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@designation"].Value = i.designation;
                    }

                    cmd.Parameters.Add("@name", SqlDbType.VarChar);
                    if (i.name == null || i.name == "")
                    {
                        cmd.Parameters["@name"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@name"].Value = i.name;
                    }

                    cmd.Parameters.Add("@mobile", SqlDbType.Int);
                    if (i.mobile.Equals(null))
                    {
                        cmd.Parameters["@mobile"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@mobile"].Value = i.mobile;
                    }

                    cmd.Parameters.Add("@emailID", SqlDbType.VarChar);
                    if (i.emailID == null || i.emailID == "")
                    {
                        cmd.Parameters["@emailID"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@emailID"].Value = i.emailID;
                    }

                    cmd.Parameters.Add("@appointmentType", SqlDbType.VarChar);
                    if (i.appointmentType == null || i.appointmentType == "")
                    {
                        cmd.Parameters["@appointmentType"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@appointmentType"].Value = i.appointmentType;
                    }

                    cmd.Parameters.Add("@appointmentDate", SqlDbType.VarChar);
                    if (i.appointmentDate == null || i.appointmentDate == "")
                    {
                        cmd.Parameters["@appointmentDate"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@appointmentDate"].Value = i.appointmentType;
                    }

                    cmd.Parameters.Add("@tenure", SqlDbType.VarChar);
                    if (i.tenure == null || i.tenure == "")
                    {
                        cmd.Parameters["@tenure"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters["@tenure"].Value = i.tenure;
                    }

                    numRowsAffected = cmd.ExecuteNonQuery();
                    if (numRowsAffected < 1)
                    {
                        // Problem inserting this row into DB
                        Exception e = new Exception("Errors encountered while saving Institution details!!!");
                        throw (e);
                    }

                }

            }
        }


        public void getManagementDetailsFromDB(string instituionId, SqlConnection con, AssetViewModels model)
        {
            String select_sql = null;
            SqlDataReader rdr;
            SqlCommand cmd = null;

            select_sql = "select instituionId, designation, name, mobile, emailID, appointmentType, appointmentDate, tenure,managementCommittee from ManagementCommitteeDetails where instituionId=@instituionId";
            cmd = new SqlCommand(select_sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@instituionId", SqlDbType.VarChar);
            cmd.Parameters["@instituionId"].Value = instituionId;

            rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                CommitteeDetails obj = new CommitteeDetails();

                if (!rdr.IsDBNull(1))
                    obj.designation = rdr.GetString(1);
                else
                    obj.designation = null;

                if (!rdr.IsDBNull(2))
                    obj.name = rdr.GetString(2);
                else
                    obj.name = null;

                if (!rdr.IsDBNull(3))
                    obj.mobile = rdr.GetInt32(3);
               
                if (!rdr.IsDBNull(4))
                    obj.emailID = rdr.GetString(4);
                else
                    obj.emailID = null;

                if (!rdr.IsDBNull(5))
                    obj.appointmentType = rdr.GetString(5);
                else
                    obj.appointmentType = null;

                if (!rdr.IsDBNull(6))
                    obj.appointmentDate = rdr.GetString(6);
                else
                    obj.appointmentDate = null;

                if (!rdr.IsDBNull(7))
                    obj.tenure = rdr.GetString(7);
                else
                    obj.tenure = null;

                model.managementDetails.Add(obj);                

            }
            HttpContext.Current.Session["managementLst"] = model.managementDetails;
            rdr.Close();
        }


        public void getDistrictAdvisoryDetailsFromDB(string instituionId, SqlConnection con, AssetViewModels model)
        {
            String select_sql = null;
            SqlDataReader rdr;
            SqlCommand cmd = null;

            select_sql = "select instituionId, designation, name, mobile, emailID, appointmentType, appointmentDate, tenure from AdvisoryCommitteeDetails  where instituionId=@instituionId";
            cmd = new SqlCommand(select_sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@instituionId", SqlDbType.VarChar);
            cmd.Parameters["@instituionId"].Value = instituionId;

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                CommitteeDetails obj = new CommitteeDetails();

                if (!rdr.IsDBNull(1))
                    obj.designation = rdr.GetString(1);
                else
                    obj.designation = null;

                if (!rdr.IsDBNull(2))
                    obj.name = rdr.GetString(2);
                else
                    obj.name = null;

                if (!rdr.IsDBNull(3))
                    obj.mobile = rdr.GetInt32(3);

                if (!rdr.IsDBNull(4))
                    obj.emailID = rdr.GetString(4);
                else
                    obj.emailID = null;

                if (!rdr.IsDBNull(5))
                    obj.appointmentType = rdr.GetString(5);
                else
                    obj.appointmentType = null;

                if (!rdr.IsDBNull(6))
                    obj.appointmentDate = rdr.GetString(6);
                else
                    obj.appointmentDate = null;

                if (!rdr.IsDBNull(7))
                    obj.tenure = rdr.GetString(7);
                else
                    obj.tenure = null;

                model.advisoryDetails.Add(obj);
            }

            HttpContext.Current.Session["advisoryLst"] = model.advisoryDetails;
            rdr.Close();
        }



    }// end of class
}