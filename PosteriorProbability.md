# Introduction #

For some practical usage posterior probability is equally important as the actual Machine Learning classification. We need to know what are the chances that this is the right classification.

If you control a wheel chair for example with left, right and forward commands then you need to say how much left, how much right or forward you need to go. Another necessity comes from the fact that classificator always returns result and this result might the best classification, but still with low probability. It you had the posterior probabilities then it would of been easy to simply put thresh-hold that classification with probability under ex. 0.2 should be ignored and this will help the wheelchair to not receive hundreds of commands for different directions for a short period of time.

Logisitic Regression provides the needed posterior probability we could say by design thanks to the sigmoid function. But other such as SVM do not. You could use the result from the voting during the multi-class classification, but this is definitely suboptimal and discrete.

There are some papers that discuss this matter:
  * "Probabilistic Outputs for SVMs and Comparisons to Regularized Likelihood Methods", Platt
  * "A note on Platt's probabilistic outputs for support vector machines", 2007
  * "A Hybrid System for Probability Estimation in Multiclass Problems Combining SVMs and Neural Networks"
  * "Probability Estimates for Multi-class Classification by Pairwise Coupling", Ting-Fan Wu, Chih-Jen Lin, Chih-Jen Lin with code here: [http://www.csie.ntu.edu.tw/~cjlin/libsvmtools/#svm\_multi\_class\_probability\_outputs](http://www.csie.ntu.edu.tw/~cjlin/libsvmtools/#svm_multi_class_probability_outputs)