﻿namespace Mb.infrastructure.Query
{
    public class ArticleQueryView
    {
        public long Id { get; set; }

        public string Titel { get; set; }

        public string ShortDiscreption { get; set; }

        public string CreationDate { get; set; }

        public string Image { get; set; }

        public string ArticleCategory { get; set; }
        public string Content { get; set; }
    }
}