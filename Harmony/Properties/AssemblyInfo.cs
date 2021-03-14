using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]

/* Allow integration tests unrestricted access for testing */
[assembly: InternalsVisibleTo("Test.Harmony, PublicKey=" +
	"00240000048000009400000006020000002400005253413100040000010001009d0f13cde5b126" +
	"c67d0c94873430cc171f8919863c6218a5bc1788a91caf6c197a851fdd4e5df5fe68726b5ca92a" +
	"cd2a47770cde3eb1538693a427a6c7591878b59dacc8fd24339f0e77f923ada3f80133f3a5b182" +
	"d7d04b16fb7bd02abff840b4b4ed9114463fef35c3437385205ebed7906a29ce6bd16a84e50129" +
	"8c8224ba")]

/* Allow the Harmony mod access to the isEnabled variable so it can turn the library
 * on and off, while denying other mods to override the Harmony Mod.
 */
[assembly: InternalsVisibleTo("HarmonyMod, PublicKey=" +
	"0024000004800000940000000602000000240000525341310004000001000100" +
	"e9f6f326593be181e1d4fea8ba7d991fc9ff3e7adf8ee659550cd00e34673409d5e177bab53f08" +
	"4410455066e2a05864973a0b91b4fd6f827f6d0c70db0299db5f7d95429418e0e58a519838ceda" +
	"4ad16caf832a9da9feac59c8ea78a37f8e22c85058e544801972d98c1ad999e6aa09374cb69606" +
	"7a66ae7b154d0e616ca0b0")]

// MonoMod.Common uses IgnoresAccessChecksTo on its end,
// but older versions of the .NET runtime bundled with older versions of Windows
// require Harmony to expose its internals instead.
// This is only relevant for when MonoMod.Common gets merged into Harmony.
[assembly: InternalsVisibleTo("MonoMod.Utils.Cil.ILGeneratorProxy, PublicKey=" +
	"002400000480000094000000060200000024000052534131000400000100010081142c1b1835f7" +
	"308d603f2e870a331179b35746e04beb0d59c4fa2ae47d988162889850950903f33e58680e0a2f" +
	"53981471dbad2f60b4e16e3ed8fa02808f71dc40b589096eccff8746d44a5a1340f600bee52b17" +
	"b39e7cafd7b6c1cbd3220d08f8af07e5777a2de6107e8b6a7ff236c2e8db1f2aacfe54f1fe5b73" +
	"b23a94c0")]

[assembly: Guid("69aee16a-b6e7-4642-2009-3928b32455df")]