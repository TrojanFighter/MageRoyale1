
using UnityEngine;
using MageRoyale.Services;
namespace MageRoyale.Entity
{
	public class EntityBase : MonoBehaviour
	{
		public int entityId = -1;

		protected virtual void Start()
		{
			Init();
		}


		protected virtual bool Init()
		{
			int id= Services.ServiceList.GameEntityManager.RegisterEntity(this);
			if (id != -1)
			{
				entityId = id;
				return true;
			}
			else
			{
				Debug.Log("EntityCreationFailed: "+gameObject.name);
				return false;
			}
		}

		public virtual void SelfDestroy()
		{
			ServiceList.GameEntityManager.UnRegisterEntity(entityId);
			Destroy(gameObject);
		}
	}
}
