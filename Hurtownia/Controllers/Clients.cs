﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Clients
    {
        //
        public static ObservableCollection<Client> ClientsList { get; set; } = new ObservableCollection<Client>();
        public static int NumberOfClients { get; set; }
        public static string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\clients.xml";


        public static void AddClient(Client newClient)
        {
            ClientsList.Add(newClient);
            SaveClients();
            SetNumberOfClients();
        }

        public static void DeleteClient(int index)
        {
            ClientsList.RemoveAt(index);
            SaveClients();
            SetNumberOfClients();
        }

        private static void SetNumberOfClients()
        {
            NumberOfClients = ClientsList.Count;
        }

        private static bool SaveClients()
        {
            try
            {
                using (var sw = new StreamWriter(FilePath))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Client>));
                    serializer.Serialize(sw, ClientsList);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool LoadClients()
        {
            try
            {
                ClientsList.Clear();
                using (var sr = new StreamReader(FilePath))
                {
                    var deSerializer = new XmlSerializer(typeof(ObservableCollection<Client>));
                    var tmpCollection =
                        (ObservableCollection<Client>) deSerializer.Deserialize(sr);
                    foreach (var item in tmpCollection)
                    {
                        ClientsList.Add(item);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static ObservableCollection<Client> SearchClient(string query)
        {
            ObservableCollection<Client> FoundClients = new ObservableCollection<Client>();

            foreach (var client in ClientsList)
            {
                string fName = client.FirstName.ToLower();
                string lName = client.LastName.ToLower();
                string Nip = client.Nip;

                if (fName.Contains(query) || lName.Contains(query) || Nip.Contains(query))
                {
                    FoundClients.Add(client);
                }

            }

            return FoundClients;

        }

        public static Client GetClient(int index)
        {
            Client client = ClientsList[index];
            return client;
        }

        public static void EditClient(Client editedClient, int index)
        {
            ClientsList.RemoveAt(index);
            ClientsList.Insert(index, editedClient);
            SaveClients();
        }
    }
}