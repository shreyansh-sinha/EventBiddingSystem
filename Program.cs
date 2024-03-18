// See https://aka.ms/new-console-template for more information
using EventBiddingSystem.Model;
using EventBiddingSystem.Repository;
using EventBiddingSystem.Service;
using EventBiddingSystem.Util;

Console.WriteLine("Hello, World!");

IUserRepository userRepository = new UserRepository();
IWinningStrategy winningStrategy = new LowBidWinningStrategy();
IEventRepository eventRepository = new EventRepository(userRepository, winningStrategy);

IUserService userService = new UserService(userRepository);
IEventService eventService = new EventService(eventRepository, userRepository);

User akshay = userService.CreateUser("1", "Akshay", 10000);
User chris = userService.CreateUser("2", "Chris", 5000);

Event @event = eventService.AddEvent("BBD", "IPhone 14", DateTime.Now, "1");

eventService.RegisterParticipant(@event.Id, "1");

eventService.SubmitBid("1", @event.Id, new List<int> { 100, 200, 300, 400, 500});

eventService.SubmitBid("2", @event.Id, new List<int> { 100, 200, 400, 500});

eventService.ChooseWinner(@event.Id);
