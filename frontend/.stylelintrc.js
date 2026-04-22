module.exports = {
  "extends": "stylelint-config-recommended",
  "plugins": ["stylelint-scss"],
  "rules": {
    "at-rule-no-unknown": null,
    "scss/at-rule-no-unknown": true,
    "no-descending-specificity": null,
    "selector-pseudo-element-no-unknown": [true, {
      "ignorePseudoElements": ["ng-deep"]
    }],
    'no-empty-source': null,
    'no-invalid-position-at-import-rule': null,
  },
}