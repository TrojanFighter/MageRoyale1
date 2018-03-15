
using UnityEngine;
using MageRoyale.Services;
namespace MageRoyale.Entity
{
	public class EntityBase : MonoBehaviour
	{
		public int entityId = 0;

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
	}
}
