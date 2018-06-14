using System.Linq;
using Solution.Model.Models;

namespace Solution.CrossCutting.Mapping
{
	public class Mapper : IMapper
	{
		public Mapper()
		{
			Configure();
		}

		public TSource Clone<TSource>(TSource source)
		{
			return AgileObjects.AgileMapper.Mapper.DeepClone(source);
		}

		public TDestination Map<TDestination>(object source)
		{
			return AgileObjects.AgileMapper.Mapper.Map(source).ToANew<TDestination>();
		}

		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return AgileObjects.AgileMapper.Mapper.Map(source).OnTo(destination);
		}

		private static void Configure()
		{
			AgileObjects.AgileMapper.Mapper.WhenMapping.From<UserModel>().To<AuthenticatedModel>()
				.Map(s => s.Source.UsersRoles.Select(x => x.Role)).To(d => d.Roles)
				.And.Map(s => s.Source.UserId).To(d => d.UserId);
		}
	}
}
