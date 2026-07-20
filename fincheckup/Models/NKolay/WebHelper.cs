using System;

namespace fincheckup.Models.Hvvn
{
    public static class WebHelper
    {
        public static string path = System.IO.Directory.GetCurrentDirectory();
        public static string pathdomain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string TagStr = "<a class=\"post-tags-item post-tags-item-title\" href=\"/tags/[tag]\"> [trg] </a>";
        public static string Socialz = "<div class=\"blog-posts-fancy-  sh-blog-fancy\">  <div class=\"blog-fancy-carousel-disabled\"> <div class=\"col-sm-2 col-lg-2 col-xs-4\"> <a href=\"http://www.facebook.com/sharer.php?u=https://www.havvana.com/posts/[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" title=\"share on facebook\"> <i class=\"fa fa-facebook-f\"></i></a> </div> <div class=\"col-sm-2 col-lg-2 col-xs-4\"> <a href=\"http://twitter.com/share?url=https://www.havvana.com/posts/[url]\" class=\"btn btn-social-icon btn-twitter\" title=\"share on twitter\" rel=\"nofollow\"> <i class=\"fa fa-twitter\"></i></a> </div> <div class=\"col-sm-2 col-lg-2 col-xs-4\"> <a href=\"http://www.linkedin.com/shareArticle?mini=true&url=https://www.havvana.com/posts/[url]\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" rel=\"nofollow\" title=\"share on linkedin\">  <i class=\"fa fa-linkedin\"></i></a> </div>  <div class=\"col-sm-2 col-lg-2 col-xs-4\"> <a href=\"http://pinterest.com/pin/create/button/?url=https://www.havvana.com/posts[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" title=\"share on pinterest\">  <i class=\"fa fa-pinterest\"></i> </a> </div>  <div class=\"col-sm-2 col-lg-2 col-xs-4\"> <a href=\"mailto:?subject=Bak%20ne%20buldum&body=https://www.havvana.com/posts/[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon  btn-facebook\" title=\"share on email\"> <i class=\"fa fa-envelope\"></i>  </a> </div> </div> </div>";
        public static string Socialza = @"<ul class=" + "\"social-list dark small\"> <li class=\"\"> <a href =\"http://www.facebook.com/sharer.php?u=https://www.havvana.com/posts/[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" title=\"share on facebook\"> <i class=\"fa fa-facebook-f\"></i></a>   </li> <li class=\"\">    <a href =\"http://twitter.com/share?url=https://www.havvana.com/posts/[url]\" class=\"btn btn-social-icon btn-twitter\" title=\"share on twitter\" rel=\"nofollow\"> <i class=\"fa fa-twitter\"></i></a>  </li>  <li class=\"\">  <a href =\"http://www.linkedin.com/shareArticle?mini=true&url=https://www.havvana.com/posts/[url]\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" rel=\"nofollow\" title=\"share on linkedin\"> <i class=\"fa fa-linkedin\"></i></a>  </li>   <li class=\"\">   <a href =\"http://pinterest.com/pin/create/button/?url=https://www.havvana.com/posts[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" title=\"share on pinterest\"> <i class=\"fa fa-pinterest\"></i> </a>   </li>  <li class=\"\">     <a href =\"mailto:?subject=Bak%20ne%20buldum&body=https://www.havvana.com/posts/[url]\" rel=\"nofollow\" target=\"_blank\" class=\"btn btn-social-icon btn-facebook\" title=\"share on email\"> <i class=\"fa fa-envelope\"></i> </a>   </li> </ul>  ";
        public static string Slugify(this string phrase)
        {
            phrase = phrase.Replace("I", "i").Replace("İ", "i");
            string str = phrase.RemoveAccent().ToLower();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty); // Remove all non valid chars          
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s", "-"); // //Replace spaces by dashes
            return str;
        }
        public static string getTime(this DateTime phrase)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - phrase.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                return ts.Seconds == 1 ? "bir saniye önce" : ts.Seconds + " saniye önce";
            }
            if (delta < 120)
            {
                return "bir dakika önce";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " dakika önce";
            }
            if (delta < 5400) // 90 * 60
            {
                return "bir saat önce";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " saat önce";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "dün";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " gün önce";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "bir ay önce" : months + " ay önce";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "bir yıl önce" : years + " yıl önce";

        }
    }
}