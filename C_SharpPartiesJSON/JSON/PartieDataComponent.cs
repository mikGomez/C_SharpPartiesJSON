using C_SharpPartiesJSON.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace C_SharpPartiesJSON.JSON
{
    public class PartieDataComponent
    {
        //Poner ruta del JSON, si la pongo relativa no funciona
        public static string Path = "C:\\Users\\migue\\Desktop\\Parties\\C_SharpPartiesJSON\\C_SharpPartiesJSON\\Data\\parties.json";
        public static ObservableCollection<Partie> readPartie()
        {
            string contenidoJson = File.ReadAllText(Path);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            return rootObject.Parties;
        }


        public static void insertPartie(Partie p)
        {
            ObservableCollection<Partie> parties = readPartie();
            parties.Add(p);
            RootObject rootObject = new RootObject();
            rootObject.Parties = parties;
            string contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path, contenidoJson);
        }

        class RootObject
        {
            [JsonProperty("parties")]
            public ObservableCollection<Models.Partie> Parties { get; set; }
            [JsonProperty("dates")]
            public ObservableCollection<Dates> Dates { get; set; } = new ObservableCollection<Dates>();

        }
        public static void deletePartie(string name)
        {
            try
            {
                // Leemos el JSON
                string contenidoJson = File.ReadAllText(Path);

                // Deserializar el contenido a un objeto RootObject
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);

                // Obtener la colección de partidos
                ObservableCollection<Partie> parties = rootObject.Parties;

                // Buscamos el partido y lo borramos
                Partie partieToRemove = parties.FirstOrDefault(p => p.name == name);

                if (partieToRemove != null)
                {
                    parties.Remove(partieToRemove);

                    // Volver a serializar y escribir en el archivo
                    contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Path, contenidoJson);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación
                Console.WriteLine($"Error al eliminar el partido: {ex.Message}");
            }
        }
        public static void updatePartie(string name, int seat, int validVotos)
        {
            try
            {
                // Leemos archivo
                string contenidoJson = File.ReadAllText(Path);

                // Deserializar el contenido a un objeto RootObject
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);

                // colección de partidos
                ObservableCollection<Partie> parties = rootObject.Parties;

                // Buscamos partido por nombre
                Partie existingPartie = parties.FirstOrDefault(p => p.name == name);

                if (existingPartie != null)
                {
                    // Modificamos partido
                    existingPartie.seat = seat;
                    existingPartie.validVot = validVotos;

                    // Serializmos
                    contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Path, contenidoJson);
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún partido con el nombre '{name}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el partido: {ex.Message}");
            }
        }

        //Leer Datos
        public static ObservableCollection<Dates> ReadDates()
        {
            string contenidoJson = File.ReadAllText(Path);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);
            return rootObject.Dates;
        }

        // Para insertar los datos
        public static void InsertDate(Dates date)
        {
            try
            {
                string contenidoJson = File.ReadAllText(Path);
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);

                // Obtenemos el partido
                ObservableCollection<Dates> dates = rootObject.Dates;

                // Agregar partido
                dates.Add(date);
                contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(Path, contenidoJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la fecha: {ex.Message}");
            }
        }

        //Para actualizar
        public static void UpdateDate(Dates existingDate)
        {
            try
            {
                string contenidoJson = File.ReadAllText(Path);
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(contenidoJson);

                // Obtenemos partido
                ObservableCollection<Dates> dates = rootObject.Dates;

                Dates dateToUpdate = dates.FirstOrDefault();

                if (dateToUpdate != null)
                {
                    dateToUpdate.pobla = existingDate.pobla;
                    dateToUpdate.absten = existingDate.absten;
                    dateToUpdate.nullVotes = existingDate.nullVotes;
                    dateToUpdate.votesV = existingDate.votesV;
                    contenidoJson = JsonConvert.SerializeObject(rootObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Path, contenidoJson);
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna fecha para actualizar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la fecha: {ex.Message}");
            }
        }

    }
}

