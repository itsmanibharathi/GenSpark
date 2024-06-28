# 3) Sort sore and name of players print the top 10

data = [
    {"name": "Player1", "score": 10},
    {"name": "Player2", "score": 40},
    {"name": "Player3", "score": 22},
    {"name": "Player4", "score": 15},
    {"name": "Player5", "score": 12},
    {"name": "Player6", "score": 18},
    {"name": "Player7", "score": 25},
    {"name": "Player8", "score": 30},
    {"name": "Player9", "score": 28},
    {"name": "Player10", "score": 35},
    {"name": "Player11", "score": 20},
    {"name": "Player12", "score": 22},
    {"name": "Player13", "score": 15},
    ]

def sort_players(data):
    data = sorted(data, key=lambda x: x["score"], reverse=True)
    for i, player in enumerate(data):
        if player["score"] == data[i-1]["score"]:
            player["rank"] = data[i-1]["rank"]
        else:
            if i == 0:
                player["rank"] = 1
            else:
                player["rank"] =data[i-1]["rank"]+ 1
    return data[:10]

print("top 10 players are:")
for player in sort_players(data):
    print("Name: {} Score: {} Rank: {}".format(player["name"], player["score"], player["rank"]))