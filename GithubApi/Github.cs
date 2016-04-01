using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GithubApi
{
	public class Github
	{
		public async Task<List<string>> GetAsync(string userName) {

			var urlApi = string.Format("https://api.github.com/users/{0}/repos", userName);

			var client = new HttpClient();
			client.DefaultRequestHeaders.Add ("User-Agent", "Other");

			var response = await client.GetAsync (urlApi);
			var content = await response.Content.ReadAsStringAsync ();

			var json = JArray.Parse (content);

			var repositories = new List<string> ();
			foreach (var item in json) {
				var repository = item.Value<string> ("full_name");
				repositories.Add (repository);
			}

			return repositories;
		}
	}
}