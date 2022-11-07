﻿namespace Dijkstra
{
	class Program
	{
		static void Main(string[] args)
		{
			string line = @"20 111 10
0 1 17 18
0 2 10 8
1 2 8 14
1 3 20 20
2 3 7 17
2 5 18 18
3 4 16 11
3 5 18 8
4 5 20 14
5 6 11 1
5 8 18 12
6 7 17 0
6 8 16 9
6 9 10 18
7 8 17 15
7 10 2 11
8 9 8 1
8 10 5 9
9 10 4 9
9 11 17 14
9 12 18 6
10 11 7 9
10 12 19 15
11 12 0 20
11 14 6 17
12 13 16 18
12 15 0 13
13 14 4 9
13 16 10 8
14 15 7 0
14 16 10 4
15 16 4 3
15 17 2 16
15 18 10 19
16 17 16 4
16 19 14 4
17 18 3 11
18 19 1 16
18 20 6 0
19 20 12 4";
			//string line;
			List<string> inputs = new List<string>();
			//while ((line = Console.ReadLine()) != null)
			//{
			//    //
			//    // Lisez les données et effectuez votre traitement */
			//    //
			inputs.AddRange(line.Split("\r\n"));
			//}

			// Vous pouvez aussi effectuer votre traitement ici après avoir lu toutes les données 
			string[] paramLine = inputs[0].Split(" ");
			int sourceVertex = 0;
			int targetVertex = int.Parse(paramLine[0]);
			int maxDuration = int.Parse(paramLine[1]);
			int maxSteps = int.Parse(paramLine[2]);

			// Création du graph
			IGraph<CostDurationStepGraphData> graph = new Graph<CostDurationStepGraphData>(
														new VertexFactory<CostDurationStepGraphData>(),
														new EdgeFactory<CostDurationStepGraphData>());

			// Ajout des connections
			for (int i = 1; i < inputs.Count; i++)
			{
				string[] currentLine = inputs[i].Split(" ");
				int origin = int.Parse(currentLine[0]);
				int target = int.Parse(currentLine[1]);
				int cost = int.Parse(currentLine[3]);
				int duration = int.Parse(currentLine[2]);

				graph.AddEdge(origin, target, new CostDurationStepGraphData(cost, duration));
			}

			// Résolution du chemin le moins couteux
			Console.WriteLine(
				graph.FindPath(
					sourceVertex,
					targetVertex,
					new CostDurationStepGraphData(-1, -1, -1),
					new OrCompositeConstraint<CostDurationStepGraphData>(
						new DurationConstraint(maxDuration),
						new StepConstraint(maxSteps))).Cost);
		}
	}
}

