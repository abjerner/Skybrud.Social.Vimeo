module.exports = function (grunt) {

    var path = require('path');

	// Load the package JSON file
	var pkg = grunt.file.readJSON('package.json');

	// Load information about the assembly
	var assembly = grunt.file.readJSON('src/' + pkg.name + '/Properties/AssemblyInfo.json');

	// Get the version of the package
    var version = assembly.informationalVersion ? assembly.informationalVersion : assembly.version;

	grunt.initConfig({
	    pkg: pkg,
		zip: {
		    release: {
		        router: function (filepath) {
					if (filepath.indexOf('/bin/Release/') >= 0) {
						return filepath.split('/bin/Release/')[1];
					} else {
						return path.basename(filepath);
					}
		        },
			    src: [
					'src/' + pkg.name + '/bin/Release/*/*.dll',
					'src/' + pkg.name + '/bin/Release/*/*.xml',
					'src/LICENSE.html'
				],
		        dest: 'releases/github/' + pkg.name + '.v' + version + '.zip'
			}
		}
	});

	grunt.loadNpmTasks('grunt-zip');

	grunt.registerTask('release', ['zip']);

	grunt.registerTask('default', ['release']);

};