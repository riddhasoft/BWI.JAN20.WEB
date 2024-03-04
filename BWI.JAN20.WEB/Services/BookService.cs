using BWI.JAN20.WEB.Models;

namespace BWI.JAN20.WEB.Services
{
    public class BookService : IBookService
    {
        readonly BWIJAN20WEBContext dbContext;
        //injection through constructor
        /// <summary>
        /// a object of dbcontext is injected 
        /// </summary>
        /// <param name="dbContext"></param>
        public BookService(BWIJAN20WEBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int DeleteBook(int id)
        {
            BookModel book = GetBook(id);
            dbContext.BookModel.Remove(book);
            int result = dbContext.SaveChanges();
            return result;
        }

        public BookModel? GetBook(int id)
        {
            return dbContext.BookModel.Find(id);
        }

        public List<BookModel> GetBooks()
        {
            return dbContext.BookModel.ToList();
        }

        public int SaveBook(BookModel model)
        {
            dbContext.BookModel.Add(model);
            return dbContext.SaveChanges();//it will return the primary key value of saved row
        }

        public int UpdateBook(BookModel model)
        {
            dbContext.BookModel.Update(model);
            return dbContext.SaveChanges();
        }

        public void AnotherPublicMethod()
        {

        }
    }
}
