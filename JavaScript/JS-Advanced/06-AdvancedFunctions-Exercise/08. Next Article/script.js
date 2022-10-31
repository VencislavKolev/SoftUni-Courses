function getArticleGenerator(articles) {
    const myArticles = articles;
    let divEl = document.getElementById('content');
    return () => {
        if (myArticles.length > 0) {
            let articleEl = document.createElement('article');
            let currentArticle = myArticles.shift();
            articleEl.textContent = currentArticle;
            divEl.appendChild(articleEl);
        }
    }
}
