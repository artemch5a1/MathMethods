using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruferCode.Core.Methods
{
    public static class CsvWorker
    {
        public static string ImportStringFromCsv(string path)
        {
            string rebers = string.Empty;

            Trace.Listeners.Add(new TextWriterTraceListener("logImport.txt"));

            Trace.WriteLine("Начало считывания из csv");

            if (!File.Exists(path))
            {
                Trace.WriteLine("Файла нет");
                Trace.Flush();
                throw new Exception("Файла не существует");
            }

            if (Path.GetExtension(path) != ".csv")
            {
                Trace.WriteLine("Файла не того формата");
                Trace.Flush();
                throw new Exception("Файл то ваш говно");
            }

            string[] line = File.ReadAllLines(path);
            
            if(line.Length  == 0 && line == null)
            {
                Trace.WriteLine("Файл был пустой");
                Trace.Flush();
                throw new Exception("Файл то ваш говно");
            }

            rebers = string.Join(" ", line);

            Trace.WriteLine("Дерево было успешно построено");

            Trace.Flush();

            return rebers;
        }

        public static void ExportCsv(string codePrufer, string path)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("logExport.txt"));

            Trace.WriteLine("Начало экспорта в csv");
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(codePrufer);
                }
                Trace.WriteLine("Экспорт в csv успешно произведен");
            }
            catch (Exception ex) 
            {
                Trace.WriteLine($"Ошибка экспорта в csv: {ex.Message}");
            }
            finally
            {
                Trace.Flush();
            }
        }
    }
}
