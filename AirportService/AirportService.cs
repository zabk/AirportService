using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace AirportService
{
    public class AirportService : IAirportService
    {
        public Airport GetAirport(string airportICAOCode)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            Airport airport = new Airport();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAirport", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter airportParameter = new SqlParameter();
                airportParameter.ParameterName = "@AirportCode";
                airportParameter.Value = airportICAOCode;
                cmd.Parameters.Add(airportParameter);
                connection.Open();
                SqlDataReader dataReader= cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    airport.AirportICAOCode = dataReader["AirportICAOCode"].ToString();
                    airport.AirportIATACode = dataReader["AirportIATACode"].ToString();
                    airport.Minima = Convert.ToInt32(dataReader["Minima"]);
                }
            }
            return airport;
        }

        public void SaveAirport(Airport airport)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SaveAirport", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter airportICAOParameter = new SqlParameter()
                {
                    ParameterName = "@AirportICAOCode",
                    Value = airport.AirportICAOCode
                };
                cmd.Parameters.Add(airportICAOParameter);

                SqlParameter airportIATAParameter = new SqlParameter()
                {
                    ParameterName = "@AirportIATACode",
                    Value = airport.AirportIATACode
                };
                cmd.Parameters.Add(airportIATAParameter);

                SqlParameter airportMinimaParameter = new SqlParameter()
                {
                    ParameterName = "@Minima",
                    Value = airport.Minima
                };
                cmd.Parameters.Add(airportMinimaParameter);

                connection.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}
