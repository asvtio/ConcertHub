using ConcertHub.Data;
using ConcertHub.Models;

namespace ConcertHub.HeplApp
{
    public static class DBAppInitializer
    {
        public static void Initialize(DBApp context)
        {
            context.Database.EnsureCreated();

            if (context.Artists.Any())
            {
                return; 
            }

            var artists = new Artist[]
       {
            new Artist {
                Name = "ASAP Rocky",
                Genre = "Hip-Hop/Rap",
                Country = "USA",
                Description = "Американский рэпер и продюсер, лидер творческого коллектива ASAP Mob"
            },
            new Artist {
                Name = "Doja Cat",
                Genre = "Pop/R&B",
                Country = "USA",
                Description = "Американская певица, автор песен и рэпер. Лауреат премии Грэмми"
            },
            new Artist {
                Name = "DPR LIVE",
                Genre = "KHH/R&B",
                Country = "South Korea",
                Description = "Корейский рэпер и автор песен под лейблом Dream Perfect Regime"
            },
            new Artist {
                Name = "SEVENTEEN",
                Genre = "K-Pop",
                Country = "South Korea",
                Description = "Южнокорейский бойбэнд из 13 участников"
            },
            new Artist {
                Name = "Brent Faiyaz",
                Genre = "Alternative R&B",
                Country = "USA",
                Description = "Американский певец и автор песен, участник группы Sonder"
            }
       };
            context.Artists.AddRange(artists);
            context.SaveChanges();

            var venues = new Venue[]
        {

            new Venue {
                Name = "Madison Square Garden",
                Address = "4 Pennsylvania Plaza, New York, NY 10001, USA",
                Capacity = 20789,
                Description = "Легендарная арена в сердце Нью-Йорка"
            },
            
         
            new Venue {
                Name = "KSPO DOME (Olympic Gymnastics Arena)",
                Address = "424 Olympic-ro, Songpa-gu, Seoul, South Korea",
                Capacity = 15000,
                Description = "Главная арена в Сеуле, где проходят крупнейшие концерты корейских артистов"
            },
            

            new Venue {
                Name = "The O2 Arena",
                Address = "Peninsula Square, London SE10 0DX, United Kingdom",
                Capacity = 20000,
                Description = "Крупнейшая крытая арена в Лондоне"
            },
            

            new Venue {
                Name = "Tokyo Dome",
                Address = "1-3-61 Koraku, Bunkyo City, Tokyo 112-0004, Japan",
                Capacity = 55000,
                Description = "Культовая арена в Токио"
            },
            
   
            new Venue {
                Name = "Mercedes-Benz Arena",
                Address = "Mühlenstraße 12-30, 10243 Berlin, Germany",
                Capacity = 17000,
                Description = "Ультрасовременная мультифункциональная арена в Берлине"
            }
        };
            context.Venues.AddRange(venues);
            context.SaveChanges();

            var concerts = new Concert[]
                  {
            new Concert {
                Title = "ASAP Rocky: TESTING World Tour - NYC",
                Description = "Эксклюзивный нью-йоркский концерт с участием гостей из A$AP Mob",
                DateTime = DateTime.Now.AddDays(45),
                ArtistId = artists[0].Id,
                VenueId = venues[0].Id, 
                BaseTicketPrice = 120,
               
            },
  
            new Concert {
                Title = "Doja Cat: Scarlet Tour - London",
                Description = "Европейская премьера нового тура с полным шоу и специальными гостями",
                DateTime = DateTime.Now.AddDays(30),
                ArtistId = artists[1].Id,
                VenueId = venues[2].Id, 
                BaseTicketPrice = 150, 
             
            },
         
            new Concert {
                Title = "DPR LIVE: IITE COOL Homecoming",
                Description = "Особое домашнее шоу в Сеуле с участием DPR IAN и DPR CREAM",
                DateTime = DateTime.Now.AddDays(60),
                ArtistId = artists[2].Id,
                VenueId = venues[1].Id, 
                BaseTicketPrice = 180, 
              
            },
      
            new Concert {
                Title = "SEVENTEEN: FOLLOW TOUR - Tokyo Dome",
                Description = "Специальное японское шоу с эксклюзивными японскими версиями песен",
                DateTime = DateTime.Now.AddDays(90),
                ArtistId = artists[3].Id,
                VenueId = venues[3].Id, 
                BaseTicketPrice = 500
              
            },
        
            new Concert {
                Title = "Brent Faiyaz: F*CK THE WORLD - Berlin",
                Description = "Выступление с живым бэндом и акустическим сетом",
                DateTime = DateTime.Now.AddDays(15),
                ArtistId = artists[4].Id,
                VenueId = venues[4].Id, 
                BaseTicketPrice = 75
              
            }
                  };
            context.Concerts.AddRange(concerts);
            context.SaveChanges();
            var users = new User[]
            {
            new User { Username = "martinlover69", Email = "martin@nycmusic.com" },
            new User { Username = "joshuahong", Email = "carat17@kakao.com" },
            new User { Username = "london_calling", Email = "music.lover@uk.com" },
            new User { Username = "maria17", Email = "techno.rb@de.com" },
            new User { Username = "alexexile", Email = "exile@jp.com" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            var tickets = new List<Ticket>();
            var random = new Random();

            foreach (var concert in concerts)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var ticket = new Ticket
                    {
                        ConcertId = concert.Id,
                        SeatNumber = $"{i}-{random.Next(1, 50)}",
                        Price = concert.BaseTicketPrice * (decimal)(0.8 + random.NextDouble() * 0.4), 
                        IsPurchased = random.Next(0, 2) == 0 
                    };

                    if (ticket.IsPurchased)
                    {
                        ticket.UserId = users[random.Next(0, users.Length)].Id;
                        ticket.PurchaseDate = DateTime.Now.AddDays(-random.Next(1, 30));
                    }

                    tickets.Add(ticket);
                }
            }
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
        }
    }
}
