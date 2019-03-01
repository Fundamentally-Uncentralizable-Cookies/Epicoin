using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Epicoin {

	public struct EFOBE {

		private List<Block> blocks;

		public struct Block {

			//TODO - Block contents

		}
	}

	internal class Validator : MainComponent<Validator.ITM> {

		public Validator(Epicore core) : base(core) {}

		protected ImmutableDictionary<string, NPcProblemWrapper> problemsRegistry;

		internal override void InitAndRun(){
			problemsRegistry = waitForITMessageOfType<ITM.GetProblemsRegistry>().problemsRegistry;
		}


		/*
		 * ITC
		 */

		internal class ITM : ITCMessage {

			internal class GetProblemsRegistry : ITM {

				public readonly ImmutableDictionary<string, NPcProblemWrapper> problemsRegistry;

				public GetProblemsRegistry(IDictionary<string, NPcProblemWrapper> reg) => problemsRegistry = reg is ImmutableDictionary<string, NPcProblemWrapper> ? reg as ImmutableDictionary<string, NPcProblemWrapper> : ImmutableDictionary.ToImmutableDictionary(reg);

			}

		}

	}

}