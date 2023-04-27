using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TinyAirlines.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TinyAirlines.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        private ObservableCollection<RaceInfo> _Races;
        public ObservableCollection<RaceInfo> Races
        {
            get { return _Races; }
            set { this.RaiseAndSetIfChanged(ref _Races, value); }
        }

        private ObservableCollection<RaceInfo> _Yesterday_Out_Races;
        public ObservableCollection<RaceInfo> Yesterday_Out_Races
        {
            get { return _Yesterday_Out_Races; }
            set { this.RaiseAndSetIfChanged(ref _Yesterday_Out_Races, value); }
        }

        private ObservableCollection<RaceInfo> _Today_Out_Races;
        public ObservableCollection<RaceInfo> Today_Out_Races
        {
            get { return _Today_Out_Races; }
            set { this.RaiseAndSetIfChanged(ref _Today_Out_Races, value); }
        }

        private ObservableCollection<RaceInfo> _Tomorrow_Out_Races;
        public ObservableCollection<RaceInfo> Tomorrow_Out_Races
        {
            get { return _Tomorrow_Out_Races; }
            set { this.RaiseAndSetIfChanged(ref _Tomorrow_Out_Races, value); }
        }

        private ObservableCollection<RaceInfo> _Yesterday_In_Races;
        public ObservableCollection<RaceInfo> Yesterday_In_Races
        {
            get { return _Yesterday_In_Races; }
            set { this.RaiseAndSetIfChanged(ref _Yesterday_In_Races, value); }
        }

        private ObservableCollection<RaceInfo> _Today_In_Races;
        public ObservableCollection<RaceInfo> Today_In_Races
        {
            get { return _Today_In_Races; }
            set { this.RaiseAndSetIfChanged(ref _Today_In_Races, value); }
        }

        private ObservableCollection<RaceInfo> _Tomorrow_In_Races;
        public ObservableCollection<RaceInfo> Tomorrow_In_Races
        {
            get { return _Tomorrow_In_Races; }
            set { this.RaiseAndSetIfChanged(ref _Tomorrow_In_Races, value); }
        }

        private bool _Otlet_Is_Enabled;
        public bool Otlet_Is_Enabled
        {
            get => _Otlet_Is_Enabled; set
            {
                {
                    this.RaiseAndSetIfChanged(ref _Otlet_Is_Enabled, value);
                }
            }
        }
        private string _DestMode;
        public string DestMode
        {
            get => _DestMode; set
            {
                {
                    this.RaiseAndSetIfChanged(ref _DestMode, value);
                }
            }
        }
        private bool _Prilet_Is_Enabled;
        public bool Prilet_Is_Enabled
        {
            get => _Prilet_Is_Enabled; set
            {
                this.RaiseAndSetIfChanged(ref _Prilet_Is_Enabled, value);
            }
        }
        private bool _Yesterday_Is_Enabled;
        public bool Yesterday_Is_Enabled
        {
            get => _Yesterday_Is_Enabled; set
            {
                this.RaiseAndSetIfChanged(ref _Yesterday_Is_Enabled, value);
            }
        }
        private bool _Today_Is_Enabled;
        public bool Today_Is_Enabled
        {
            get => _Today_Is_Enabled; set
            {
                this.RaiseAndSetIfChanged(ref _Today_Is_Enabled, value);
            }
        }
        private bool _Tomorrow_Is_Enabled;
        public bool Tomorrow_Is_Enabled
        {
            get => _Tomorrow_Is_Enabled; set
            {
                this.RaiseAndSetIfChanged(ref _Tomorrow_Is_Enabled, value);
            }
        }

        public MainWindowViewModel()
        {
            _DestMode = "Назначение";
            _Otlet_Is_Enabled = false;
            _Prilet_Is_Enabled = true;
            _Yesterday_Is_Enabled = true;
            _Today_Is_Enabled = false;
            _Tomorrow_Is_Enabled = true;
            Yesterday_Out_Races = new ObservableCollection<RaceInfo>();
            Yesterday_In_Races = new ObservableCollection<RaceInfo>();
            Today_Out_Races = new ObservableCollection<RaceInfo>();
            Today_In_Races = new ObservableCollection<RaceInfo>();
            Tomorrow_Out_Races = new ObservableCollection<RaceInfo>();
            Tomorrow_In_Races = new ObservableCollection<RaceInfo>();
            Races = new ObservableCollection<RaceInfo>();
            DateTime actualData = new DateTime();
            actualData = DateTime.Now;
            string yesterdayDate = "";
            yesterdayDate = actualData.AddDays(-1).ToString().Substring(0, 10);
            string todayDate = "";
            todayDate = actualData.ToString().Substring(0, 10);
            string tomorrowDate = "";
            tomorrowDate = actualData.AddDays(+1).ToString().Substring(0, 10);
            // Debug.WriteLine($"{yesterdayDate} \t {todayDate} \t {tomorrowDate}");
            //Console.Read();
            string sqlExpression = "SELECT * FROM Arrival";
            string sqlExpression1 = "SELECT * FROM Departure";
            using (var connection = new SqliteConnection("Data Source=..\\..\\..\\Assets\\race_info_data_base.db"))
            {
                //SQLitePCL.raw.SetProvider();
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read() == true)
                        {
                            var id = reader.GetValue(0);
                            string race = reader.GetValue(1).ToString();
                            string destination = reader.GetValue(2).ToString();
                            string exp_time = reader.GetValue(3).ToString();
                            string real_time = reader.GetValue(4).ToString();
                            string sector = reader.GetValue(5).ToString();
                            string status = reader.GetValue(6).ToString();
                            string type = reader.GetValue(7).ToString();
                            string baggage = reader.GetValue(8).ToString();
                            string date = reader.GetValue(9).ToString();
                            if (date == yesterdayDate)
                            {
                                Yesterday_In_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, status, type, baggage, date));
                            }
                            if (date == todayDate)
                            {
                                Today_In_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, status, type, baggage, date));
                            }
                            if (date == tomorrowDate)
                            {
                                Tomorrow_In_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, status, type, baggage, date));
                            }
                            // Debug.WriteLine($"{race} \t {destination} \t {exp_time} \t {real_time} \t {sector} \t {status} \t {type} \t {baggage} \t {date}");
                        }
                    }
                }
                command = new SqliteCommand(sqlExpression1, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows == true)
                    {
                        while (reader.Read() == true)
                        {
                            var id = reader.GetValue(0);
                            string race = reader.GetValue(1).ToString();
                            string destination = reader.GetValue(2).ToString();
                            string exp_time = reader.GetValue(3).ToString();
                            string real_time = reader.GetValue(4).ToString();
                            string sector = reader.GetValue(5).ToString();
                            string status = reader.GetValue(6).ToString();
                            string reg_start = reader.GetValue(7).ToString();
                            string boarding = reader.GetValue(8).ToString();
                            string sector_exit = reader.GetValue(9).ToString();
                            string type = reader.GetValue(10).ToString();
                            string reg_stand = reader.GetValue(11).ToString();
                            string date = reader.GetValue(12).ToString();
                            if (date == yesterdayDate)
                            {
                                Yesterday_Out_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, type, reg_start, reg_stand, sector_exit, boarding, date, status));
                            }
                            if (date == todayDate)
                            {
                                Today_Out_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, type, reg_start, reg_stand, sector_exit, boarding, date, status));
                            }
                            if (date == tomorrowDate)
                            {
                                Tomorrow_Out_Races.Add(new RaceInfo(race, destination, exp_time, real_time, sector, type, reg_start, reg_stand, sector_exit, boarding, date, status));
                            }
                            // Debug.WriteLine($"{race} \t {destination} \t {exp_time} \t {real_time} \t {sector} \t {status} \t {type} \t {baggage} \t {date}");
                        }
                    }
                }
                connection.Close();
            }
            //Debug.WriteLine(Yesterday_In_Races.Count);
            //Debug.WriteLine(Today_In_Races.Count);
            //Debug.WriteLine(Tomorrow_In_Races.Count);
            //Debug.WriteLine(Yesterday_Out_Races.Count);
            //Debug.WriteLine(Today_Out_Races.Count);
            //Debug.WriteLine(Tomorrow_Out_Races.Count);
            Races = Today_Out_Races;
        }
        public void Otlet_Button()
        {
            Otlet_Is_Enabled = false;
            Prilet_Is_Enabled = true;
            DestMode = "Назначение";
            if (Yesterday_Is_Enabled == false)
            {
                Races = Yesterday_Out_Races;
            }
            if (Today_Is_Enabled == false)
            {
                Races = Today_Out_Races;
            }
            if (Tomorrow_Is_Enabled == false)
            {
                Races = Tomorrow_Out_Races;
            }
        }
        public void Prilet_Button()
        {
            Otlet_Is_Enabled = true;
            Prilet_Is_Enabled = false;
            DestMode = "Пункт вылета";
            if (Yesterday_Is_Enabled == false)
            {
                Races = Yesterday_In_Races;
            }
            if (Today_Is_Enabled == false)
            {
                Races = Today_In_Races;
            }
            if (Tomorrow_Is_Enabled == false)
            {
                Races = Tomorrow_In_Races;
            }
        }
        public void Yesterday_Button()
        {
            Yesterday_Is_Enabled = false;
            Today_Is_Enabled = true;
            Tomorrow_Is_Enabled = true;
            if (Prilet_Is_Enabled == false)
            {
                Races = Yesterday_In_Races;
            }
            else
            {
                Races = Yesterday_Out_Races;
            }
        }
        public void Today_Button()
        {
            Yesterday_Is_Enabled = true;
            Today_Is_Enabled = false;
            Tomorrow_Is_Enabled = true;
            if (Prilet_Is_Enabled == false)
            {
                Races = Today_In_Races;
            }
            else
            {
                Races = Today_Out_Races;
            }
        }
        public void Tomorrow_Button()
        {
            Yesterday_Is_Enabled = true;
            Today_Is_Enabled = true;
            Tomorrow_Is_Enabled = false;
            if (Prilet_Is_Enabled == false)
            {
                Races = Tomorrow_In_Races;
            }
            else
            {
                Races = Tomorrow_Out_Races;
            }
        }
    }
}