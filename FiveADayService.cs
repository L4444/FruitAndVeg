
using FruitAndVegApp;


namespace FruitAndVegApp
{
    public class FiveADayService
    {
        private FiveADayContext _context = default!;


        public FiveADayService(FiveADayContext fiveADayContext)
        {
            Console.WriteLine("FiveADayService constructor called");
            _context = fiveADayContext;



        }
        public IEnumerable<FiveADay> SelectAll()
        {
            return _context.FiveADays;
        }

        public void Delete(int id)
        {
            //Console.WriteLine($"---- Deleting Five a day service with id {id}");


            _context.FiveADays.Remove(findById(id));
            _context.SaveChanges();
        }

        public void Insert(FiveADay f)
        {
            // Don't let the User set the new record Id
            f.Id = 0;
            _context.FiveADays.Add(f);
            _context.SaveChanges();
        }

        public void Update(FiveADay f)
        {

            _context.FiveADays.Entry(findById(f.Id)).CurrentValues.SetValues(f);
            _context.SaveChanges();

        }

        public FiveADay Select(int id)
        {

            Console.WriteLine($"FiveADayService Select() called with id={id}");
            return findById(id);
        }

        private FiveADay findById(int id)
        {
            FiveADay? entry = _context.FiveADays.Find(id);


            if (entry == null)
            {
                throw new KeyNotFoundException($"id = {id}");
            }

            return entry;

        }



    }


}