        if (_userThreads is null)
        {
            //TODO: Ta bort!
            _userThreads = new List<UserThread>
            {
                new UserThread { Id = 1, Header = "Jag gillar spel", Score = 0, Comments = null, Text = "Jag gillar att spela spel", UserId = 1 },
                new UserThread { Id = 2, Header = "Jag gillar spel 2", Score = 3, Comments = null, Text = "Jag gillar att spela spel 2", UserId = 2 }
            };
        }
        return _userThreads;
    }

