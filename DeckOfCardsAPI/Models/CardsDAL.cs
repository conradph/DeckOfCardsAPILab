using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCardsAPI.Models
{
    public class CardsDAL
    {
        public Deck GenerateDeck()
        {
            //First step is to put in your endpoint, your URL
            string url = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1"; //add in the id given to the function in order to access the specified person

            //Next we need to create the request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Next if your API needs any kind of login or key, that may go here
            //SWAPI doesn't need anything so we are good here

            //Now we're ready to send off our request and grab the servers response
            //Inside our response, the resulting data lives
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the results into a StreamReader which will then gives us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our response file and returns each line until it hits the end
            string result = rd.ReadToEnd();

            //This line converts out JSON string into a person object automagically
            Deck d = JsonConvert.DeserializeObject<Deck>(result);

            //Later we'll convert our string into a model which makes it much eaaser to use for .net things
            return d;
        }
        public CardDraw DrawCards(string deckID, int count)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckID}/draw/?count=" + count; //add in the id given to the function in order to access the specified person

            //Next we need to create the request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //Now we're ready to send off our request and grab the servers response
            //Inside our response, the resulting data lives
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Pull the results into a StreamReader which will then gives us a string
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //Grab our response string - read to end starts at the top of our response file and returns each line until it hits the end
            string result = rd.ReadToEnd();

            //This line converts out JSON string into a person object automagically
            CardDraw c = JsonConvert.DeserializeObject<CardDraw>(result);
            
            //Later we'll convert our string into a model which makes it much eaaser to use for .net things
            return c;
        }
    }
}
