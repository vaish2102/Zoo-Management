using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using NLog;
using Logging;

namespace Zoo_Management.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase{
        private readonly ZooManagementDbContext _context;
        private static readonly NLog.ILogger Logger = LogManager.GetLogger("File Logger");
        public AnimalController(ZooManagementDbContext context){
            _context = context;
            LogConfig.ConfigureLog();
        }
        
        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal(){
            Logger.Info("Getting the list of animals");
            return await _context.Animal.ToListAsync();
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id){
            var animal = await _context.Animal.FindAsync(id);
            Logger.Info("Getting the details of "+animal);
            if (animal == null){
                Logger.Error("There are no details for "+animal);
                return NotFound();
            }
            return animal;
        }

        // POST: api/Animal
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal){
            Logger.Info("Adding animal records to database");
            _context.Animal.Add(animal);
            Logger.Info("Animal records added to database successfully");
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // POST:api/MockData/MOCK_DATA.json
        [HttpPost("{fileName}")]
         public async Task<ActionResult<Animal>> PostMockData(string fileName){
            Logger.Info("Adding mock animal data to database from "+fileName);
            List<Animal> animalList = new List<Animal>(); 
            using (StreamReader reader = new StreamReader(fileName)){ 
                Logger.Info("Reading the file");
                string animalData = reader.ReadToEnd();  
                animalList = JsonSerializer.Deserialize<List<Animal>>(animalData); 
                foreach(var animalObj in animalList){
                     _context.Animal.Add(animalObj);
                      Logger.Info("Adding the mock data to database");
                    await _context.SaveChangesAsync();
                    Logger.Info("Mock data added to database successfully ");
                }    
            }
              return RedirectToAction("GetAnimal");
        }        
    }
}