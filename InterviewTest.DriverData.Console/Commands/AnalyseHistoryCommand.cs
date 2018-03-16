using System;
using System.Collections.Generic;
using System.Linq;
using InterviewTest.DriverData;
using InterviewTest.DriverData.Analysers;

namespace InterviewTest.Commands
{
	public class AnalyseHistoryCommand
	{
        // BONUS: What's great about readonly?
        /*
         * A readonly field can be initialized only once as it is immutable.
         * In our case, an Analyser is readonly as it will be instantiated only once as the analysis would be done for one driver at a time         
        */
        private readonly IAnalyser _analyser;

		public AnalyseHistoryCommand(IReadOnlyCollection<string> arguments)
		{
			var analysisType = arguments.Single();

			_analyser = AnalyserLookup.GetAnalyser(analysisType);
		}

		public void Execute()
		{
			var analysis = _analyser.Analyse(CannedDrivingData.History);

			Console.Out.WriteLine($"Analysed period: {analysis.AnalysedDuration:g}");
			Console.Out.WriteLine($"Driver rating: {analysis.DriverRating:P}");
		}
	}
}
