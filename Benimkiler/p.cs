using Benimkiler.Roles;

namespace Survey.Benimkiler;

public static class p
{
    public static void f(string yazi)
    {
        Console.WriteLine("------------------------------------[BOYRAZ]" + yazi + "-----------------------------------");
    }

    public static Roles RoleToEnum(string role){
          Roles newRole = (Roles)Enum.Parse(typeof(Roles), role);
          return newRole;
    }
}