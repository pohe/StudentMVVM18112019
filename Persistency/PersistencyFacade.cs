using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using StudentMVVM18112019.Common;
using StudentMVVM18112019.Model;

namespace StudentMVVM18112019.Persistency
{
    public class PersistencyFacade
    {
        private static string jsonFileName = "StudentsAsJson.dat";

        
        public static async Task SaveStudentsAsJsonAsync(ObservableCollection<Student> students)
        {
            string studentsJsonString = JsonConvert.SerializeObject(students);
            await SerializeStudentsFileAsync(studentsJsonString, jsonFileName);
        }

        public static async Task<ObservableCollection<Student>> LoadStudentsFromJsonAsync()
        {
            string studentsJsonString = await DeSerializeStudentsFileAsync(jsonFileName);
            return (ObservableCollection<Student>)JsonConvert.DeserializeObject(studentsJsonString, typeof(ObservableCollection<Student>));
        }


        public static async Task SerializeStudentsFileAsync(string studentsString, string fileName)
        {
            try
            {
                StorageFile localFile =
                    await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                        CreationCollisionOption.ReplaceExisting);

                await Task.Run(() => Thread.Sleep(5000));
                await FileIO.WriteTextAsync(localFile, studentsString);
            }
            catch (IOException iox)
            {
                MessageDialogHelper.Show("Error creating the file", "IO error");
            }
        }

        public static async Task<string> DeSerializeStudentsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

                await Task.Run(() => Thread.Sleep(5000));
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {

                MessageDialogHelper.Show(
                    "Loading for the first time? Try Adding and Save some Students before you are trying to Load students!",
                    "File not found!");
                return null;
            }
            catch (IOException iox)
            {
                MessageDialogHelper.Show("Error loading the file", "IO error!");
                return null;
            }
        }


    }
}
