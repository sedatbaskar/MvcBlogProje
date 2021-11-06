using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoauthor = new Repository<Author>();
        //Tüm yazar listesi
        public List<Author> GetAll()
        {

            return repoauthor.List();


        }
        //Yeni Yazar Ekleme
        public int AddAuthorBL(Author p)
        {
            if (p.AuthorName == "" | p.AboutShort == "" | p.AuthorImage == "")
            {

                return -1;
            }
            return repoauthor.Insert(p);
        }

        // Yazarı id değerine göre edit sayfasına taşıma işlemi
        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorID == id);


        }
        public int EditAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AboutShort = p.AboutShort;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            return repoauthor.Update(author);

        }
    }
}
