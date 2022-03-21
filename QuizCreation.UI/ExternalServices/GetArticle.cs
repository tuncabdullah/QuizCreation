using QuizCreation.Entities.DTO.Exam;
using System.ServiceModel.Syndication;
using System.Xml;

namespace QuizCreation.UI.ExternalServices
{
    public class GetArticle
    {
        public List<ArticleViewModel> GetList(int count)
        {
            var xmlReader = XmlReader.Create("https://www.wired.com/feed/rss");
            var syndicationFeed = SyndicationFeed.Load(xmlReader);
            var dataall = syndicationFeed.Items.OrderByDescending(x => x.PublishDate);
            var countBasedData = (count == 0) ? dataall : dataall.Take(count);
            var articleList = new List<ArticleViewModel>();
            foreach (var data in countBasedData)
            {
                var article = new ArticleViewModel() { Id = data.Id, Title = data.Title.Text, Description = data.Summary.Text };
                articleList.Add(article);
            }
            return articleList;

        }
        public ArticleViewModel GetById(string Id)
        {
            var xmlReader = XmlReader.Create("https://www.wired.com/feed/rss");
            var syndicationFeed = SyndicationFeed.Load(xmlReader);
            var data = syndicationFeed.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault(x => x.Id == Id);
            var article = new ArticleViewModel() { Id = data.Id, Title = data.Title.Text, Description = data.Summary.Text };
            return article;

        }
    }
}
