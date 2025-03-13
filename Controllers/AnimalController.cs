using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.Extensions.Logging;
using Logging;

namespace Zoo_Management.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase{
        private readonly ILogger<AnimalController> _logger;
        private readonly ZooManagementDbContext _context;
        public AnimalController(ZooManagementDbContext context,ILogger<AnimalController> logger)
        {
            _context = context;
             LogConfig.ConfigureLog();
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into AnimalController");
        }
        
    
        // private static readonly NLog.ILogger Logger = LogManager.GetLogger("File Logger");
        
        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal(){
            _logger.LogInformation("Getting the list of animals");
            return await _context.Animal.ToListAsync();
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id){
            var animal = await _context.Animal.FindAsync(id);
           _logger.LogInformation("Getting the details of "+animal);
            if (animal == null){
                _logger.LogError("There are no details for "+animal);
                return NotFound();
            }
            return animal;
        }

        // POST: api/Animal
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal){
            _logger.LogInformation("Adding animal records to database");
            _context.Animal.Add(animal);
            _logger.LogInformation("Animal records added to database successfully");
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // POST:api/MockData/MOCK_DATA.json
        [HttpPost("{fileName}")]
         public async Task<ActionResult<Animal>> PostMockData(string fileName){
            _logger.LogInformation("Adding mock animal data to database from "+fileName);
            List<Animal> animalList = new List<Animal>(); 
            using (StreamReader reader = new StreamReader(fileName)){ 
                _logger.LogInformation("Reading the file");
                string animalData = reader.ReadToEnd();  
                animalList = JsonSerializer.Deserialize<List<Animal>>(animalData); 
                foreach(var animalObj in animalList){
                    _context.Animal.Add(animalObj);
                    _logger.LogInformation("Adding"+ animalObj.Name+" to the database"); 
                }   
                await _context.SaveChangesAsync();
                _logger.LogInformation("Mock data added to database successfully "); 
            }
              return RedirectToAction("GetAnimal");
        }   

        //  // GET: api/Animal/5
        // [HttpGet("{name}")]
        // public async Task<ActionResult<Animal>> GetAnimalByName(string name){
        //     List animal = await _context.Animal.ToListAsync();
        //     Logger.Info("Getting the details for Animal by its name "+animal);
        //     if (animal == null){
        //         Logger.Error("There are no details for Animal by name "+animal);
        //         return NotFound();
        //     }
        //     return animal;
        // }     
    }
}