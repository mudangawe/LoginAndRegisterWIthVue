const presets = [
	['@babel/preset-react'],
	[
		'@babel/env',
		{
			"loose": true,
			"targets": {
			  "browsers": [
				"> 0.1%",
				"last 3 versions",
				"ie 10",
				"ie 11"
			  ]
			}
		 }
	]
];

const plugins = [
	['@babel/plugin-proposal-class-properties'],
	[
		'babel-plugin-styled-components',
		{
			pure: true
		}
  ],
  ["@babel/plugin-transform-runtime"]
];

module.exports = { presets, plugins };