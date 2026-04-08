# Muses (Predictive Typing) in memoQ

## Definition and Purpose

Muses function as heavy resources in memoQ that provide subsegment suggestions to users as they type in the translation editor. These tools work by collecting single and multiword expressions in source and target content, identifying correlations between source and target, and suggesting the target expressions as a suggestion in the predictive typing.

## Functional Capabilities

The system operates through expression correlation detection. Muses examine source and target materials to identify corresponding terms without requiring explicit relationship indicators in the source material.

## Availability and Scope

Muses are restricted to specific project types. Users can employ them in local projects only and also function within a local copy of an online project with offline copies of the TMs (translation memories).

## Training and Maintenance

The system supports retraining functionality. Users can retrain your Muse when for example your TM has grown, allowing the resource to adapt as translation memory expands.

## Practical Example

The documentation illustrates functionality through a concrete scenario: training a Muse with several thousand segments. When source text contains "term base" and corresponding target contains "Termdatenbank," the Muse detects correlations between such expressions. During actual translation work, it compares the source segment with the extracted source expression from the training, and it suggests the target expression in the predictive typing during translation.
