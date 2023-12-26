using Bonsai.Components.Goals;
using Bonsai.Model;

namespace Bonsai.Injection
{
	public class ComponentInjector
	{
		private Dictionary<Type, Dictionary<Type, Type>> componentRegistrationMapping;

		public ComponentInjector()
		{
			componentRegistrationMapping = [];
		}

		public ComponentKindRegistrar<TGoal> For<TGoal>() where TGoal : Goal
		{
			return new ComponentKindRegistrar<TGoal>(this);
		}

		public ComponentKindRegistrar For(Type goalType)
		{
			if (goalType is null || !goalType.IsAssignableTo(typeof(Goal))) throw new InvalidOperationException(); // TODO: injection exception!

			return new ComponentKindRegistrar(goalType, this);
		}

		public IEnumerable<Type> GetSupportedGoalTypes(Type kindType)
		{
			if (kindType is null || !kindType.IsInterface) throw new InvalidOperationException(); // TODO: injection exception

			if (!kindType.GetInterfaces().Any(i => i.GetGenericTypeDefinition() == typeof(IGoalComponent<>))) throw new InvalidOperationException(); // TODO: injection exception!

			return componentRegistrationMapping.Where(_ => _.Key.GetGenericTypeDefinition() == kindType).SelectMany(_ => _.Value.Keys);
		}

		public readonly record struct ComponentKindRegistrar<TGoal> where TGoal : Goal
		{
			private readonly ComponentInjector injector;

			public ComponentKindRegistrar(ComponentInjector injector)
			{
				this.injector = injector;
			}

			public ComponentTypeRegistrar<TKind> OfKind<TKind>() where TKind : IGoalComponent<TGoal>
			{
				if (!typeof(TKind).IsInterface) throw new InvalidOperationException(); // TODO: injection exception

				return new ComponentTypeRegistrar<TKind>(injector);
			}

			public Type ResolveKind<TKind>() where TKind : IGoalComponent<TGoal>
			{
				if (!typeof(TKind).IsInterface) throw new InvalidOperationException(); // TODO: injection exception

				if (!injector.componentRegistrationMapping.TryGetValue(typeof(TKind), out Dictionary<Type, Type>? goalMapping)) throw new InvalidOperationException(); // TODO: missing injection exception

				if (!goalMapping.TryGetValue(typeof(TGoal), out Type? componentType)) throw new InvalidOperationException(); // TODO: missing injection exception

				return componentType;
			}

			public readonly record struct ComponentTypeRegistrar<TKind> where TKind : IGoalComponent<TGoal>
			{
				private readonly ComponentInjector injector;

				public ComponentTypeRegistrar(ComponentInjector injector)
				{
					this.injector = injector;
				}

				public void Inject<TComponent>() where TComponent : class, TKind
				{
					var goalType = typeof(TGoal);
					var kindType = typeof(TKind);

					if (!injector.componentRegistrationMapping.TryGetValue(kindType, out Dictionary<Type, Type>? goalMapping))
					{
						goalMapping = [];

						injector.componentRegistrationMapping[kindType] = goalMapping;
					}

					if (goalMapping.ContainsKey(goalType)) throw new InvalidOperationException(); // TODO: duplicate injection exception

					goalMapping[goalType] = typeof(TComponent);
				}
			}
		}

		public readonly record struct ComponentKindRegistrar
		{
			private readonly Type goalType;
			private readonly ComponentInjector injector;

			public ComponentKindRegistrar(Type goalType, ComponentInjector injector)
			{
				this.goalType = goalType;
				this.injector = injector;
			}

			public Type ResolveKind(Type kindType)
			{
				if (kindType is null || !kindType.IsInterface) throw new InvalidOperationException(); // TODO: injection exception

				if (!kindType.IsAssignableTo(typeof(IGoalComponent<>).MakeGenericType(goalType))) throw new InvalidOperationException(); // TODO: injection exception!

				if (!injector.componentRegistrationMapping.TryGetValue(kindType, out Dictionary<Type, Type>? goalMapping)) throw new InvalidOperationException(); // TODO: missing injection exception

				if (!goalMapping.TryGetValue(goalType, out Type? componentType)) throw new InvalidOperationException(); // TODO: missing injection exception

				return componentType;
			}
		}
	}
}
