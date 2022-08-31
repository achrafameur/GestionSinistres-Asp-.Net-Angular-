::Ignorer les Fichier
cd Insurise.Api/Properties
git update-index --skip-worktree launchSettings.json
cd .. 
git update-index --skip-worktree appsettings.Development.json
git update-index --skip-worktree appsettings.Production.json
git update-index --skip-worktree appsettings.json
echo "Files ignored"
