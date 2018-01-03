using AngleSharp.Dom.Html;

namespace TestingGit.Core
{
	interface IParser<T> where T : class
	{
		T Parse(IHtmlDocument document);
	}
}
