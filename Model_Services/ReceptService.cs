using System.Text.Json;
using Recepten_bootcamp_AI.Models;

namespace Recepten_bootcamp_AI.Services
{
    public class ReceptService
    {
        private readonly string _bestandspad;

        public ReceptService()
        {
            _bestandspad = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "recepten.json"
            );
        }

        public List<Recept> HaalReceptenOp()
        {
            if (!File.Exists(_bestandspad))
            {
                return new List<Recept>();
            }

            string json = File.ReadAllText(_bestandspad);

            return JsonSerializer.Deserialize<List<Recept>>(json)
                   ?? new List<Recept>();
        }

        public void VoegReceptToe(Recept recept)
        {
            List<Recept> recepten = HaalReceptenOp();

            recept.Id = recepten.Count + 1;

            recepten.Add(recept);

            string json = JsonSerializer.Serialize(
                recepten,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            File.WriteAllText(_bestandspad, json);
        }
    }
}