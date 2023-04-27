using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyAirlines.Models
{
    public class RaceInfo
    {
        private string _Race_From;
        public string Race_From
        {
            get => _Race_From;
            set
            {
                _Race_From = value;
            }
        }
        private string _Race_To;
        public string Race_To
        {
            get => _Race_To;
            set
            {
                _Race_To = value;
            }
        }
        private string _Race_Number;
        public string Race_Number
        {
            get => _Race_Number;
            set
            {
                _Race_Number = value;
            }
        }
        private string _Race_Exp_Start;
        public string Race_Exp_Start
        {
            get => _Race_Exp_Start;
            set
            {
                _Race_Exp_Start = value;
            }
        }
        private string _Race_Real_Start;
        public string Race_Real_Start
        {
            get => _Race_Real_Start;
            set
            {
                _Race_Real_Start = value;
            }
        }
        private string _Sector;
        public string Sector
        {
            get => _Sector;
            set
            {
                _Sector = value;
            }
        }
        private string _Race_Company;
        public string Race_Company
        {
            get => _Race_Company;
            set
            {
                _Race_Company = value;
            }
        }
        private string _Type;
        public string Type
        {
            get => _Type;
            set
            {
                _Type = value;
            }

        }
        private string _Reg_Start;
        public string Reg_Start
        {
            get => _Reg_Start;
            set
            {
                _Reg_Start = value;
            }
        }
        private string _Reg_Stand;
        public string Reg_Stand
        {
            get => _Reg_Stand;
            set
            {
                _Reg_Stand = value;
            }
        }
        private string _Sector_Exit;
        public string Sector_Exit
        {
            get => _Sector_Exit;
            set
            {
                _Sector_Exit = value;
            }
        }
        private string _Boarding;
        public string Boarding
        {
            get => _Boarding;
            set
            {
                _Boarding = value;
            }
        }
        private string _Race_Image;
        public string Race_Image
        {
            get => _Race_Image;
            set
            {
                _Race_Image = value;
            }
        }
        private string _Date;
        public string Date
        {
            get => _Date;
            set
            {
                _Date = value;
            }
        }

        private string _Short_Race_Number;
        public string Short_Race_Number
        {
            get => _Short_Race_Number;
            set
            {
                _Short_Race_Number = value;
            }
        }

        private string _Short_Race_From;
        public string Short_Race_From
        {
            get => _Short_Race_From;
            set
            {
                _Short_Race_From = value;
            }
        }

        private string _Short_Race_Exp_Start;
        public string Short_Race_Exp_Start
        {
            get => _Short_Race_Exp_Start;
            set
            {
                _Short_Race_Exp_Start = value;
            }
        }

        private string _Short_Race_Real_Start;
        public string Short_Race_Real_Start
        {
            get => _Short_Race_Real_Start;
            set
            {
                _Short_Race_Real_Start = value;
            }
        }

        private string _Short_Sector;
        public string Short_Sector
        {
            get => _Short_Sector;
            set
            {
                _Short_Sector = value;
            }
        }

        private string _Short_Status;
        public string Short_Status
        {
            get => _Short_Status;
            set
            {
                _Short_Status = value;
            }
        }

        private string _Baggage;
        public string Baggage
        {
            get => _Baggage;
            set
            {
                _Baggage = value;
            }
        }


        private string _Status;
        public string Status
        {
            get => _Status;
            set
            {
                _Status = value;
            }
        }

        private string Company_Finder(string Type)
        {
            string[] Abb = {"6R", "DP", "G6", "S7", "SU", "U6", "UT" };
            string[] Full_Name = {"Алроса", "Победа", "FlyArna", "S7 Airlines", "Аэрофлот", "Ural Airlines", "ЮТэйр" };
            string temp = Type.Substring(0, 2);
            int i;
            for (i = 0; i < Abb.Length; i++)
            {
                if (Abb[i] == temp)
                {
                    break;
                }
            }
            return Full_Name[i];
        }

        private string Image_Finder(string Type)
        {
            string[] Abb = { "6R", "DP", "G6", "S7", "SU", "U6", "UT" };
            string temp = Type.Substring(0, 2);
            int i;
            for (i = 0; i < Abb.Length; i++)
            {
                if (Abb[i] == temp)
                {
                    break;
                }
            }
            string answer = "..\\..\\..\\Assets\\" + Abb[i] + ".png";
            return answer;
        }

        public RaceInfo(string race_Number, string race_From, string race_Exp_Start, string race_Real_Start, string sector,
            string status, string type, string baggage, string date)
        {
            Race_Number = "Номер рейса: " + race_Number;
            Race_From = race_From + "-> Новосибирск";
            Race_Exp_Start = "По расписанию: " + race_Exp_Start;
            Race_Real_Start = "Расчетное время: " + race_Real_Start;
            Sector = "Сектор: " + sector;
            Race_Company = "Авиакомпания: ";
            Race_Company += Company_Finder(race_Number);
            Status = status;
            Type = "Тип ВС: " + type;
            Baggage = "Лента выдачи багажа: " + baggage;
            Date = date;
            Race_Image = Image_Finder(race_Number);
            Short_Race_Number = race_Number;
            Short_Race_Exp_Start = race_Exp_Start;
            Short_Race_From = race_From;
            Short_Race_Real_Start = race_Real_Start;
            Short_Sector = sector;
            Short_Status = status;
        }

        public RaceInfo(string race_Number, string race_From, string race_Exp_Start, string race_Real_Start, string sector,
            string type, string reg_Start, string reg_Stand,
             string sector_Exit, string boarding, string date, string status)
        {
            Race_From = "Новосибирск -> " + race_From;
            Race_Number = "Номер рейса: " + race_Number;
            Race_Exp_Start = "По расписанию: " + race_Exp_Start;
            Race_Real_Start = "Расчетное время: " + race_Real_Start;
            Sector = "Сектор: " + sector;
            Short_Race_Number = race_Number;
            Short_Race_Exp_Start = race_Exp_Start;
            Short_Race_From = race_From;
            Short_Race_Real_Start = race_Real_Start;
            Short_Status = status;
            Short_Sector = sector;
            Race_Company = "Авиакомпания: ";
            Race_Company += Company_Finder(race_Number);
            Type = "Тип ВС: " + type;
            Reg_Start = "Начало регистрации: " + reg_Start;
            Reg_Stand = "Стойка регистрации: " + reg_Stand;
            Sector_Exit = "Сектор выхода на посадку: " + sector_Exit;
            Boarding = "Посадка на борт: " + boarding;
            Date = date;
            Status ="Статус: " + status;
            Race_Image = Image_Finder(race_Number);
        }
    }
}
