using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GithubApi
{
	public class Github
	{
		public async Task<List<string>> GetReposAsync(string userName) {

			var urlApi = string.Format("https://api.github.com/users/{0}/repos", userName);

			var client = new HttpClient();
			client.DefaultRequestHeaders.Add ("User-Agent", "Other");

			var response = await client.GetAsync (urlApi);
			var content = await response.Content.ReadAsStringAsync ();

			var repositories = new List<string> ();

			try {
				var json = JArray.Parse (content);
				
				foreach (var item in json) {
					var repository = item.Value<string> ("name");
					repositories.Add (repository);
				}
			} catch {
				
			}

			return repositories;
		}

		public async Task<List<string>> GetFollowersAsync(string userName) {

			var urlApi = string.Format("https://api.github.com/users/{0}/followers", userName);

			var client = new HttpClient();
			client.DefaultRequestHeaders.Add ("User-Agent", "Other");

			var response = await client.GetAsync (urlApi);
			var content = await response.Content.ReadAsStringAsync ();

			var followers = new List<string> ();

			try {
				var json = JArray.Parse (content);

				foreach (var item in json) {
					var follower = item.Value<string> ("login");
					followers.Add (follower);
				}
			} catch {
			}

			return followers;
		}
	}
}