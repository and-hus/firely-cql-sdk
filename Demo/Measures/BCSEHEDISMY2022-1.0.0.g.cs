﻿using System;
using Tuples;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;
[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.0.0")]
[CqlLibrary("BCSEHEDISMY2022", "1.0.0")]
public class BCSEHEDISMY2022_1_0_0
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Absence_of_Left_Breast;
    internal Lazy<CqlValueSet> __Absence_of_Right_Breast;
    internal Lazy<CqlValueSet> __Bilateral_Mastectomy;
    internal Lazy<CqlValueSet> __Bilateral_Modifier;
    internal Lazy<CqlValueSet> __Clinical_Bilateral_Modifier;
    internal Lazy<CqlValueSet> __Clinical_Left_Modifier;
    internal Lazy<CqlValueSet> __Clinical_Right_Modifier;
    internal Lazy<CqlValueSet> __Clinical_Unilateral_Mastectomy;
    internal Lazy<CqlValueSet> __History_of_Bilateral_Mastectomy;
    internal Lazy<CqlValueSet> __Left_Modifier;
    internal Lazy<CqlValueSet> __Mammography;
    internal Lazy<CqlValueSet> __Right_Modifier;
    internal Lazy<CqlValueSet> __Unilateral_Mastectomy;
    internal Lazy<CqlValueSet> __Unilateral_Mastectomy_Left;
    internal Lazy<CqlValueSet> __Unilateral_Mastectomy_Right;
    internal Lazy<CqlInterval<CqlDateTime>> __Measurement_Period;
    internal Lazy<Patient> __Patient;
    internal Lazy<CqlDateTime> __October_1_Two_Years_Prior_to_the_Measurement_Period;
    internal Lazy<CqlInterval<CqlDateTime>> __Participation_Period;
    internal Lazy<IEnumerable<Coverage>> __Member_Coverage;
    internal Lazy<bool?> __Enrolled_During_Participation_Period;
    internal Lazy<bool?> __Initial_Population;
    internal Lazy<bool?> __Denominator;
    internal Lazy<IEnumerable<Condition>> __Right_Mastectomy_Diagnosis;
    internal Lazy<IEnumerable<Procedure>> __Right_Mastectomy_Procedure;
    internal Lazy<IEnumerable<Condition>> __Left_Mastectomy_Diagnosis;
    internal Lazy<IEnumerable<Procedure>> __Left_Mastectomy_Procedure;
    internal Lazy<IEnumerable<Condition>> __Bilateral_Mastectomy_Diagnosis;
    internal Lazy<IEnumerable<Procedure>> __Bilateral_Mastectomy_Procedure;
    internal Lazy<bool?> __Mastectomy_Exclusion;
    internal Lazy<bool?> __Exclusions;
    internal Lazy<bool?> __Numerator;

    #endregion
    public BCSEHEDISMY2022_1_0_0(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_0_001 = new FHIRHelpers_4_0_001(context);
        NCQAHealthPlanEnrollment_1_0_0 = new NCQAHealthPlanEnrollment_1_0_0(context);
        NCQAStatus_1_0_0 = new NCQAStatus_1_0_0(context);
        NCQAFHIRBase_1_0_0 = new NCQAFHIRBase_1_0_0(context);
        NCQAHospice_1_0_0 = new NCQAHospice_1_0_0(context);
        NCQAAdvancedIllnessandFrailty_1_0_0 = new NCQAAdvancedIllnessandFrailty_1_0_0(context);
        NCQAPalliativeCare_1_0_0 = new NCQAPalliativeCare_1_0_0(context);

        __Absence_of_Left_Breast = new Lazy<CqlValueSet>(this.Absence_of_Left_Breast_Value);
        __Absence_of_Right_Breast = new Lazy<CqlValueSet>(this.Absence_of_Right_Breast_Value);
        __Bilateral_Mastectomy = new Lazy<CqlValueSet>(this.Bilateral_Mastectomy_Value);
        __Bilateral_Modifier = new Lazy<CqlValueSet>(this.Bilateral_Modifier_Value);
        __Clinical_Bilateral_Modifier = new Lazy<CqlValueSet>(this.Clinical_Bilateral_Modifier_Value);
        __Clinical_Left_Modifier = new Lazy<CqlValueSet>(this.Clinical_Left_Modifier_Value);
        __Clinical_Right_Modifier = new Lazy<CqlValueSet>(this.Clinical_Right_Modifier_Value);
        __Clinical_Unilateral_Mastectomy = new Lazy<CqlValueSet>(this.Clinical_Unilateral_Mastectomy_Value);
        __History_of_Bilateral_Mastectomy = new Lazy<CqlValueSet>(this.History_of_Bilateral_Mastectomy_Value);
        __Left_Modifier = new Lazy<CqlValueSet>(this.Left_Modifier_Value);
        __Mammography = new Lazy<CqlValueSet>(this.Mammography_Value);
        __Right_Modifier = new Lazy<CqlValueSet>(this.Right_Modifier_Value);
        __Unilateral_Mastectomy = new Lazy<CqlValueSet>(this.Unilateral_Mastectomy_Value);
        __Unilateral_Mastectomy_Left = new Lazy<CqlValueSet>(this.Unilateral_Mastectomy_Left_Value);
        __Unilateral_Mastectomy_Right = new Lazy<CqlValueSet>(this.Unilateral_Mastectomy_Right_Value);
        __Measurement_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Measurement_Period_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __October_1_Two_Years_Prior_to_the_Measurement_Period = new Lazy<CqlDateTime>(this.October_1_Two_Years_Prior_to_the_Measurement_Period_Value);
        __Participation_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Participation_Period_Value);
        __Member_Coverage = new Lazy<IEnumerable<Coverage>>(this.Member_Coverage_Value);
        __Enrolled_During_Participation_Period = new Lazy<bool?>(this.Enrolled_During_Participation_Period_Value);
        __Initial_Population = new Lazy<bool?>(this.Initial_Population_Value);
        __Denominator = new Lazy<bool?>(this.Denominator_Value);
        __Right_Mastectomy_Diagnosis = new Lazy<IEnumerable<Condition>>(this.Right_Mastectomy_Diagnosis_Value);
        __Right_Mastectomy_Procedure = new Lazy<IEnumerable<Procedure>>(this.Right_Mastectomy_Procedure_Value);
        __Left_Mastectomy_Diagnosis = new Lazy<IEnumerable<Condition>>(this.Left_Mastectomy_Diagnosis_Value);
        __Left_Mastectomy_Procedure = new Lazy<IEnumerable<Procedure>>(this.Left_Mastectomy_Procedure_Value);
        __Bilateral_Mastectomy_Diagnosis = new Lazy<IEnumerable<Condition>>(this.Bilateral_Mastectomy_Diagnosis_Value);
        __Bilateral_Mastectomy_Procedure = new Lazy<IEnumerable<Procedure>>(this.Bilateral_Mastectomy_Procedure_Value);
        __Mastectomy_Exclusion = new Lazy<bool?>(this.Mastectomy_Exclusion_Value);
        __Exclusions = new Lazy<bool?>(this.Exclusions_Value);
        __Numerator = new Lazy<bool?>(this.Numerator_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_0_001 FHIRHelpers_4_0_001 { get; }
    public NCQAHealthPlanEnrollment_1_0_0 NCQAHealthPlanEnrollment_1_0_0 { get; }
    public NCQAStatus_1_0_0 NCQAStatus_1_0_0 { get; }
    public NCQAFHIRBase_1_0_0 NCQAFHIRBase_1_0_0 { get; }
    public NCQAHospice_1_0_0 NCQAHospice_1_0_0 { get; }
    public NCQAAdvancedIllnessandFrailty_1_0_0 NCQAAdvancedIllnessandFrailty_1_0_0 { get; }
    public NCQAPalliativeCare_1_0_0 NCQAPalliativeCare_1_0_0 { get; }

    #endregion

	private CqlValueSet Absence_of_Left_Breast_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1329", null);

    [CqlDeclaration("Absence of Left Breast")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1329")]
	public CqlValueSet Absence_of_Left_Breast() => 
		__Absence_of_Left_Breast.Value;

	private CqlValueSet Absence_of_Right_Breast_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1330", null);

    [CqlDeclaration("Absence of Right Breast")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1330")]
	public CqlValueSet Absence_of_Right_Breast() => 
		__Absence_of_Right_Breast.Value;

	private CqlValueSet Bilateral_Mastectomy_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1042", null);

    [CqlDeclaration("Bilateral Mastectomy")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1042")]
	public CqlValueSet Bilateral_Mastectomy() => 
		__Bilateral_Mastectomy.Value;

	private CqlValueSet Bilateral_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1043", null);

    [CqlDeclaration("Bilateral Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1043")]
	public CqlValueSet Bilateral_Modifier() => 
		__Bilateral_Modifier.Value;

	private CqlValueSet Clinical_Bilateral_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1951", null);

    [CqlDeclaration("Clinical Bilateral Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1951")]
	public CqlValueSet Clinical_Bilateral_Modifier() => 
		__Clinical_Bilateral_Modifier.Value;

	private CqlValueSet Clinical_Left_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1949", null);

    [CqlDeclaration("Clinical Left Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1949")]
	public CqlValueSet Clinical_Left_Modifier() => 
		__Clinical_Left_Modifier.Value;

	private CqlValueSet Clinical_Right_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1950", null);

    [CqlDeclaration("Clinical Right Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1950")]
	public CqlValueSet Clinical_Right_Modifier() => 
		__Clinical_Right_Modifier.Value;

	private CqlValueSet Clinical_Unilateral_Mastectomy_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1948", null);

    [CqlDeclaration("Clinical Unilateral Mastectomy")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1948")]
	public CqlValueSet Clinical_Unilateral_Mastectomy() => 
		__Clinical_Unilateral_Mastectomy.Value;

	private CqlValueSet History_of_Bilateral_Mastectomy_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1331", null);

    [CqlDeclaration("History of Bilateral Mastectomy")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1331")]
	public CqlValueSet History_of_Bilateral_Mastectomy() => 
		__History_of_Bilateral_Mastectomy.Value;

	private CqlValueSet Left_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1148", null);

    [CqlDeclaration("Left Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1148")]
	public CqlValueSet Left_Modifier() => 
		__Left_Modifier.Value;

	private CqlValueSet Mammography_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1168", null);

    [CqlDeclaration("Mammography")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1168")]
	public CqlValueSet Mammography() => 
		__Mammography.Value;

	private CqlValueSet Right_Modifier_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1230", null);

    [CqlDeclaration("Right Modifier")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1230")]
	public CqlValueSet Right_Modifier() => 
		__Right_Modifier.Value;

	private CqlValueSet Unilateral_Mastectomy_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1256", null);

    [CqlDeclaration("Unilateral Mastectomy")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1256")]
	public CqlValueSet Unilateral_Mastectomy() => 
		__Unilateral_Mastectomy.Value;

	private CqlValueSet Unilateral_Mastectomy_Left_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1334", null);

    [CqlDeclaration("Unilateral Mastectomy Left")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1334")]
	public CqlValueSet Unilateral_Mastectomy_Left() => 
		__Unilateral_Mastectomy_Left.Value;

	private CqlValueSet Unilateral_Mastectomy_Right_Value() => 
		new CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1335", null);

    [CqlDeclaration("Unilateral Mastectomy Right")]
    [CqlValueSet("https://www.ncqa.org/fhir/valueset/2.16.840.1.113883.3.464.1004.1335")]
	public CqlValueSet Unilateral_Mastectomy_Right() => 
		__Unilateral_Mastectomy_Right.Value;

	private CqlInterval<CqlDateTime> Measurement_Period_Value()
	{
		object a_ = context.ResolveParameter("BCSEHEDISMY2022-1.0.0", "Measurement Period", null);

		return (CqlInterval<CqlDateTime>)a_;
	}

    [CqlDeclaration("Measurement Period")]
	public CqlInterval<CqlDateTime> Measurement_Period() => 
		__Measurement_Period.Value;

	private Patient Patient_Value()
	{
		IEnumerable<Patient> a_ = context.Operators.RetrieveByValueSet<Patient>(null, null);
		Patient b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient() => 
		__Patient.Value;

	private CqlDateTime October_1_Two_Years_Prior_to_the_Measurement_Period_Value()
	{
		CqlInterval<CqlDateTime> a_ = this.Measurement_Period();
		CqlDateTime b_ = context.Operators.Start(a_);
		int? c_ = context.Operators.DateTimeComponentFrom(b_, "year");
		int? d_ = context.Operators.Subtract(c_, 2);
		decimal? e_ = context.Operators.ConvertIntegerToDecimal(0);
		CqlDateTime f_ = context.Operators.DateTime(d_, 10, 1, 0, 0, 0, 0, e_);

		return f_;
	}

    [CqlDeclaration("October 1 Two Years Prior to the Measurement Period")]
	public CqlDateTime October_1_Two_Years_Prior_to_the_Measurement_Period() => 
		__October_1_Two_Years_Prior_to_the_Measurement_Period.Value;

	private CqlInterval<CqlDateTime> Participation_Period_Value()
	{
		CqlDateTime a_ = this.October_1_Two_Years_Prior_to_the_Measurement_Period();
		CqlInterval<CqlDateTime> b_ = this.Measurement_Period();
		CqlDateTime c_ = context.Operators.End(b_);
		CqlInterval<CqlDateTime> d_ = context.Operators.Interval(a_, c_, true, true);

		return d_;
	}

    [CqlDeclaration("Participation Period")]
	public CqlInterval<CqlDateTime> Participation_Period() => 
		__Participation_Period.Value;

	private IEnumerable<Coverage> Member_Coverage_Value()
	{
		IEnumerable<Coverage> a_ = context.Operators.RetrieveByValueSet<Coverage>(null, null);
		bool? b_(Coverage C)
		{
			CqlInterval<CqlDateTime> d_ = NCQAFHIRBase_1_0_0.Normalize_Interval((C?.Period as object));
			CqlInterval<CqlDateTime> e_ = this.Participation_Period();
			bool? f_ = context.Operators.Overlaps(d_, e_, null);

			return f_;
		};
		IEnumerable<Coverage> c_ = context.Operators.Where<Coverage>(a_, b_);

		return c_;
	}

    [CqlDeclaration("Member Coverage")]
	public IEnumerable<Coverage> Member_Coverage() => 
		__Member_Coverage.Value;

	private bool? Enrolled_During_Participation_Period_Value()
	{
		IEnumerable<Coverage> a_ = this.Member_Coverage();
		CqlInterval<CqlDateTime> b_ = this.Measurement_Period();
		CqlDateTime c_ = context.Operators.End(b_);
		CqlDate d_ = context.Operators.DateFrom(c_);
		CqlDateTime e_ = this.October_1_Two_Years_Prior_to_the_Measurement_Period();
		CqlDate f_ = context.Operators.DateFrom(e_);
		CqlDateTime h_ = context.Operators.End(b_);
		CqlDate i_ = context.Operators.DateFrom(h_);
		CqlQuantity j_ = context.Operators.Quantity(2m, "years");
		CqlDate k_ = context.Operators.Subtract(i_, j_);
		CqlInterval<CqlDate> l_ = context.Operators.Interval(f_, k_, true, true);
		bool? m_ = NCQAHealthPlanEnrollment_1_0_0.Health_Plan_Enrollment_Criteria(a_, d_, l_, 0);
		CqlDateTime p_ = context.Operators.End(b_);
		CqlDate q_ = context.Operators.DateFrom(p_);
		CqlDateTime s_ = context.Operators.Start(b_);
		CqlDate t_ = context.Operators.DateFrom(s_);
		CqlQuantity u_ = context.Operators.Quantity(1m, "year");
		CqlDate v_ = context.Operators.Subtract(t_, u_);
		CqlDateTime x_ = context.Operators.End(b_);
		CqlDate y_ = context.Operators.DateFrom(x_);
		CqlDate aa_ = context.Operators.Subtract(y_, u_);
		CqlInterval<CqlDate> ab_ = context.Operators.Interval(v_, aa_, true, true);
		bool? ac_ = NCQAHealthPlanEnrollment_1_0_0.Health_Plan_Enrollment_Criteria(a_, q_, ab_, 45);
		bool? ad_ = context.Operators.And(m_, ac_);
		CqlDateTime ag_ = context.Operators.End(b_);
		CqlDate ah_ = context.Operators.DateFrom(ag_);
		CqlDateTime aj_ = context.Operators.Start(b_);
		CqlDate ak_ = context.Operators.DateFrom(aj_);
		CqlDateTime am_ = context.Operators.End(b_);
		CqlDate an_ = context.Operators.DateFrom(am_);
		CqlInterval<CqlDate> ao_ = context.Operators.Interval(ak_, an_, true, true);
		bool? ap_ = NCQAHealthPlanEnrollment_1_0_0.Health_Plan_Enrollment_Criteria(a_, ah_, ao_, 45);
		bool? aq_ = context.Operators.And(ad_, ap_);

		return aq_;
	}

    [CqlDeclaration("Enrolled During Participation Period")]
	public bool? Enrolled_During_Participation_Period() => 
		__Enrolled_During_Participation_Period.Value;

	private bool? Initial_Population_Value()
	{
		Patient a_ = this.Patient();
		CqlDate b_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		CqlInterval<CqlDateTime> c_ = this.Measurement_Period();
		CqlDateTime d_ = context.Operators.End(c_);
		CqlDate e_ = context.Operators.DateFrom(d_);
		int? f_ = context.Operators.CalculateAgeAt(b_, e_, "year");
		CqlInterval<int?> g_ = context.Operators.Interval(52, 74, true, true);
		bool? h_ = context.Operators.In<int?>(f_, g_, null);
		bool? j_ = context.Operators.Equal(a_?.GenderElement?.Value, "female");
		bool? k_ = context.Operators.And(h_, j_);
		bool? l_ = this.Enrolled_During_Participation_Period();
		bool? m_ = context.Operators.And(k_, l_);

		return m_;
	}

    [CqlDeclaration("Initial Population")]
	public bool? Initial_Population() => 
		__Initial_Population.Value;

	private bool? Denominator_Value()
	{
		bool? a_ = this.Initial_Population();

		return a_;
	}

    [CqlDeclaration("Denominator")]
	public bool? Denominator() => 
		__Denominator.Value;

	private IEnumerable<Condition> Right_Mastectomy_Diagnosis_Value()
	{
		CqlValueSet a_ = this.Absence_of_Right_Breast();
		IEnumerable<Condition> b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		IEnumerable<Condition> c_ = NCQAStatus_1_0_0.Active_Condition(b_);
		bool? d_(Condition RightMastectomyDiagnosis)
		{
			CqlInterval<CqlDateTime> f_ = NCQAFHIRBase_1_0_0.Prevalence_Period(RightMastectomyDiagnosis);
			CqlDateTime g_ = context.Operators.Start(f_);
			CqlInterval<CqlDateTime> h_ = this.Measurement_Period();
			CqlDateTime i_ = context.Operators.End(h_);
			bool? j_ = context.Operators.SameOrBefore(g_, i_, null);

			return j_;
		};
		IEnumerable<Condition> e_ = context.Operators.Where<Condition>(c_, d_);

		return e_;
	}

    [CqlDeclaration("Right Mastectomy Diagnosis")]
	public IEnumerable<Condition> Right_Mastectomy_Diagnosis() => 
		__Right_Mastectomy_Diagnosis.Value;

	private IEnumerable<Procedure> Right_Mastectomy_Procedure_Value()
	{
		CqlValueSet a_ = this.Unilateral_Mastectomy_Right();
		IEnumerable<Procedure> b_ = context.Operators.RetrieveByValueSet<Procedure>(a_, null);
		IEnumerable<Procedure> c_ = NCQAStatus_1_0_0.Completed_Procedure(b_);
		CqlValueSet d_ = this.Unilateral_Mastectomy();
		IEnumerable<Procedure> e_ = context.Operators.RetrieveByValueSet<Procedure>(d_, null);
		IEnumerable<Procedure> f_ = NCQAStatus_1_0_0.Completed_Procedure(e_);
		bool? g_(Procedure UnilateralMastectomyProcedure)
		{
			CqlConcept r_(CodeableConcept X)
			{
				CqlConcept v_ = FHIRHelpers_4_0_001.ToConcept(X);

				return v_;
			};
			IEnumerable<CqlConcept> s_ = context.Operators.Select<CodeableConcept, CqlConcept>((UnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), r_);
			CqlValueSet t_ = this.Right_Modifier();
			bool? u_ = context.Operators.ConceptsInValueSet(s_, t_);

			return u_;
		};
		IEnumerable<Procedure> h_ = context.Operators.Where<Procedure>(f_, g_);
		IEnumerable<Procedure> i_ = context.Operators.ListUnion<Procedure>(c_, h_);
		CqlValueSet j_ = this.Clinical_Unilateral_Mastectomy();
		IEnumerable<Procedure> k_ = context.Operators.RetrieveByValueSet<Procedure>(j_, null);
		IEnumerable<Procedure> l_ = NCQAStatus_1_0_0.Completed_Procedure(k_);
		bool? m_(Procedure ClinicalUnilateralMastectomyProcedure)
		{
			CqlConcept w_(CodeableConcept X)
			{
				CqlConcept aa_ = FHIRHelpers_4_0_001.ToConcept(X);

				return aa_;
			};
			IEnumerable<CqlConcept> x_ = context.Operators.Select<CodeableConcept, CqlConcept>((ClinicalUnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), w_);
			CqlValueSet y_ = this.Clinical_Right_Modifier();
			bool? z_ = context.Operators.ConceptsInValueSet(x_, y_);

			return z_;
		};
		IEnumerable<Procedure> n_ = context.Operators.Where<Procedure>(l_, m_);
		IEnumerable<Procedure> o_ = context.Operators.ListUnion<Procedure>(i_, n_);
		bool? p_(Procedure RightMastectomyProcedure)
		{
			CqlInterval<CqlDateTime> ab_ = NCQAFHIRBase_1_0_0.Normalize_Interval(RightMastectomyProcedure?.Performed);
			CqlDateTime ac_ = context.Operators.End(ab_);
			CqlInterval<CqlDateTime> ad_ = this.Measurement_Period();
			CqlDateTime ae_ = context.Operators.End(ad_);
			bool? af_ = context.Operators.SameOrBefore(ac_, ae_, null);

			return af_;
		};
		IEnumerable<Procedure> q_ = context.Operators.Where<Procedure>(o_, p_);

		return q_;
	}

    [CqlDeclaration("Right Mastectomy Procedure")]
	public IEnumerable<Procedure> Right_Mastectomy_Procedure() => 
		__Right_Mastectomy_Procedure.Value;

	private IEnumerable<Condition> Left_Mastectomy_Diagnosis_Value()
	{
		CqlValueSet a_ = this.Absence_of_Left_Breast();
		IEnumerable<Condition> b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		IEnumerable<Condition> c_ = NCQAStatus_1_0_0.Active_Condition(b_);
		bool? d_(Condition LeftMastectomyDiagnosis)
		{
			CqlInterval<CqlDateTime> f_ = NCQAFHIRBase_1_0_0.Prevalence_Period(LeftMastectomyDiagnosis);
			CqlDateTime g_ = context.Operators.Start(f_);
			CqlInterval<CqlDateTime> h_ = this.Measurement_Period();
			CqlDateTime i_ = context.Operators.End(h_);
			bool? j_ = context.Operators.SameOrBefore(g_, i_, null);

			return j_;
		};
		IEnumerable<Condition> e_ = context.Operators.Where<Condition>(c_, d_);

		return e_;
	}

    [CqlDeclaration("Left Mastectomy Diagnosis")]
	public IEnumerable<Condition> Left_Mastectomy_Diagnosis() => 
		__Left_Mastectomy_Diagnosis.Value;

	private IEnumerable<Procedure> Left_Mastectomy_Procedure_Value()
	{
		CqlValueSet a_ = this.Unilateral_Mastectomy_Left();
		IEnumerable<Procedure> b_ = context.Operators.RetrieveByValueSet<Procedure>(a_, null);
		IEnumerable<Procedure> c_ = NCQAStatus_1_0_0.Completed_Procedure(b_);
		CqlValueSet d_ = this.Unilateral_Mastectomy();
		IEnumerable<Procedure> e_ = context.Operators.RetrieveByValueSet<Procedure>(d_, null);
		IEnumerable<Procedure> f_ = NCQAStatus_1_0_0.Completed_Procedure(e_);
		bool? g_(Procedure UnilateralMastectomyProcedure)
		{
			CqlConcept r_(CodeableConcept X)
			{
				CqlConcept v_ = FHIRHelpers_4_0_001.ToConcept(X);

				return v_;
			};
			IEnumerable<CqlConcept> s_ = context.Operators.Select<CodeableConcept, CqlConcept>((UnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), r_);
			CqlValueSet t_ = this.Left_Modifier();
			bool? u_ = context.Operators.ConceptsInValueSet(s_, t_);

			return u_;
		};
		IEnumerable<Procedure> h_ = context.Operators.Where<Procedure>(f_, g_);
		IEnumerable<Procedure> i_ = context.Operators.ListUnion<Procedure>(c_, h_);
		CqlValueSet j_ = this.Clinical_Unilateral_Mastectomy();
		IEnumerable<Procedure> k_ = context.Operators.RetrieveByValueSet<Procedure>(j_, null);
		IEnumerable<Procedure> l_ = NCQAStatus_1_0_0.Completed_Procedure(k_);
		bool? m_(Procedure ClinicalUnilateralMastectomyProcedure)
		{
			CqlConcept w_(CodeableConcept X)
			{
				CqlConcept aa_ = FHIRHelpers_4_0_001.ToConcept(X);

				return aa_;
			};
			IEnumerable<CqlConcept> x_ = context.Operators.Select<CodeableConcept, CqlConcept>((ClinicalUnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), w_);
			CqlValueSet y_ = this.Clinical_Left_Modifier();
			bool? z_ = context.Operators.ConceptsInValueSet(x_, y_);

			return z_;
		};
		IEnumerable<Procedure> n_ = context.Operators.Where<Procedure>(l_, m_);
		IEnumerable<Procedure> o_ = context.Operators.ListUnion<Procedure>(i_, n_);
		bool? p_(Procedure LeftMastectomyProcedure)
		{
			CqlInterval<CqlDateTime> ab_ = NCQAFHIRBase_1_0_0.Normalize_Interval(LeftMastectomyProcedure?.Performed);
			CqlDateTime ac_ = context.Operators.End(ab_);
			CqlInterval<CqlDateTime> ad_ = this.Measurement_Period();
			CqlDateTime ae_ = context.Operators.End(ad_);
			bool? af_ = context.Operators.SameOrBefore(ac_, ae_, null);

			return af_;
		};
		IEnumerable<Procedure> q_ = context.Operators.Where<Procedure>(o_, p_);

		return q_;
	}

    [CqlDeclaration("Left Mastectomy Procedure")]
	public IEnumerable<Procedure> Left_Mastectomy_Procedure() => 
		__Left_Mastectomy_Procedure.Value;

	private IEnumerable<Condition> Bilateral_Mastectomy_Diagnosis_Value()
	{
		CqlValueSet a_ = this.History_of_Bilateral_Mastectomy();
		IEnumerable<Condition> b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		IEnumerable<Condition> c_ = NCQAStatus_1_0_0.Active_Condition(b_);
		bool? d_(Condition BilateralMastectomyHistory)
		{
			CqlInterval<CqlDateTime> f_ = NCQAFHIRBase_1_0_0.Prevalence_Period(BilateralMastectomyHistory);
			CqlDateTime g_ = context.Operators.Start(f_);
			CqlInterval<CqlDateTime> h_ = this.Measurement_Period();
			CqlDateTime i_ = context.Operators.End(h_);
			bool? j_ = context.Operators.SameOrBefore(g_, i_, null);

			return j_;
		};
		IEnumerable<Condition> e_ = context.Operators.Where<Condition>(c_, d_);

		return e_;
	}

    [CqlDeclaration("Bilateral Mastectomy Diagnosis")]
	public IEnumerable<Condition> Bilateral_Mastectomy_Diagnosis() => 
		__Bilateral_Mastectomy_Diagnosis.Value;

	private IEnumerable<Procedure> Bilateral_Mastectomy_Procedure_Value()
	{
		CqlValueSet a_ = this.Bilateral_Mastectomy();
		IEnumerable<Procedure> b_ = context.Operators.RetrieveByValueSet<Procedure>(a_, null);
		IEnumerable<Procedure> c_ = NCQAStatus_1_0_0.Completed_Procedure(b_);
		CqlValueSet d_ = this.Unilateral_Mastectomy();
		IEnumerable<Procedure> e_ = context.Operators.RetrieveByValueSet<Procedure>(d_, null);
		IEnumerable<Procedure> f_ = NCQAStatus_1_0_0.Completed_Procedure(e_);
		bool? g_(Procedure UnilateralMastectomyProcedure)
		{
			CqlConcept r_(CodeableConcept X)
			{
				CqlConcept v_ = FHIRHelpers_4_0_001.ToConcept(X);

				return v_;
			};
			IEnumerable<CqlConcept> s_ = context.Operators.Select<CodeableConcept, CqlConcept>((UnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), r_);
			CqlValueSet t_ = this.Bilateral_Modifier();
			bool? u_ = context.Operators.ConceptsInValueSet(s_, t_);

			return u_;
		};
		IEnumerable<Procedure> h_ = context.Operators.Where<Procedure>(f_, g_);
		IEnumerable<Procedure> i_ = context.Operators.ListUnion<Procedure>(c_, h_);
		CqlValueSet j_ = this.Clinical_Unilateral_Mastectomy();
		IEnumerable<Procedure> k_ = context.Operators.RetrieveByValueSet<Procedure>(j_, null);
		IEnumerable<Procedure> l_ = NCQAStatus_1_0_0.Completed_Procedure(k_);
		bool? m_(Procedure ClinicalUnilateralMastectomyProcedure)
		{
			CqlConcept w_(CodeableConcept X)
			{
				CqlConcept aa_ = FHIRHelpers_4_0_001.ToConcept(X);

				return aa_;
			};
			IEnumerable<CqlConcept> x_ = context.Operators.Select<CodeableConcept, CqlConcept>((ClinicalUnilateralMastectomyProcedure?.BodySite as IEnumerable<CodeableConcept>), w_);
			CqlValueSet y_ = this.Clinical_Bilateral_Modifier();
			bool? z_ = context.Operators.ConceptsInValueSet(x_, y_);

			return z_;
		};
		IEnumerable<Procedure> n_ = context.Operators.Where<Procedure>(l_, m_);
		IEnumerable<Procedure> o_ = context.Operators.ListUnion<Procedure>(i_, n_);
		bool? p_(Procedure BilateralMastectomyPerformed)
		{
			CqlInterval<CqlDateTime> ab_ = NCQAFHIRBase_1_0_0.Normalize_Interval(BilateralMastectomyPerformed?.Performed);
			CqlDateTime ac_ = context.Operators.End(ab_);
			CqlInterval<CqlDateTime> ad_ = this.Measurement_Period();
			CqlDateTime ae_ = context.Operators.End(ad_);
			bool? af_ = context.Operators.SameOrBefore(ac_, ae_, null);

			return af_;
		};
		IEnumerable<Procedure> q_ = context.Operators.Where<Procedure>(o_, p_);

		return q_;
	}

    [CqlDeclaration("Bilateral Mastectomy Procedure")]
	public IEnumerable<Procedure> Bilateral_Mastectomy_Procedure() => 
		__Bilateral_Mastectomy_Procedure.Value;

	private bool? Mastectomy_Exclusion_Value()
	{
		IEnumerable<Condition> a_ = this.Right_Mastectomy_Diagnosis();
		bool? b_ = context.Operators.Exists<Condition>(a_);
		IEnumerable<Procedure> c_ = this.Right_Mastectomy_Procedure();
		bool? d_ = context.Operators.Exists<Procedure>(c_);
		bool? e_ = context.Operators.Or(b_, d_);
		IEnumerable<Condition> f_ = this.Left_Mastectomy_Diagnosis();
		bool? g_ = context.Operators.Exists<Condition>(f_);
		IEnumerable<Procedure> h_ = this.Left_Mastectomy_Procedure();
		bool? i_ = context.Operators.Exists<Procedure>(h_);
		bool? j_ = context.Operators.Or(g_, i_);
		bool? k_ = context.Operators.And(e_, j_);
		IEnumerable<Condition> l_ = this.Bilateral_Mastectomy_Diagnosis();
		bool? m_ = context.Operators.Exists<Condition>(l_);
		bool? n_ = context.Operators.Or(k_, m_);
		IEnumerable<Procedure> o_ = this.Bilateral_Mastectomy_Procedure();
		bool? p_ = context.Operators.Exists<Procedure>(o_);
		bool? q_ = context.Operators.Or(n_, p_);

		return q_;
	}

    [CqlDeclaration("Mastectomy Exclusion")]
	public bool? Mastectomy_Exclusion() => 
		__Mastectomy_Exclusion.Value;

	private bool? Exclusions_Value()
	{
		bool? a_ = NCQAHospice_1_0_0.Hospice_Intervention_or_Encounter();
		bool? b_ = this.Mastectomy_Exclusion();
		bool? c_ = context.Operators.Or(a_, b_);
		bool? d_ = NCQAAdvancedIllnessandFrailty_1_0_0.Advanced_Illness_and_Frailty_Exclusion_Not_Including_Over_Age_80();
		bool? e_ = context.Operators.Or(c_, d_);
		CqlInterval<CqlDateTime> f_ = this.Measurement_Period();
		bool? g_ = NCQAPalliativeCare_1_0_0.Palliative_Care_Overlapping_Period(f_);
		bool? h_ = context.Operators.Or(e_, g_);

		return h_;
	}

    [CqlDeclaration("Exclusions")]
	public bool? Exclusions() => 
		__Exclusions.Value;

	private bool? Numerator_Value()
	{
		CqlValueSet a_ = this.Mammography();
		IEnumerable<Observation> b_ = context.Operators.RetrieveByValueSet<Observation>(a_, null);
		bool? c_(Observation Mammogram)
		{
			CqlInterval<CqlDateTime> f_ = NCQAFHIRBase_1_0_0.Normalize_Interval(Mammogram?.Effective);
			CqlDateTime g_ = context.Operators.End(f_);
			CqlInterval<CqlDateTime> h_ = this.Participation_Period();
			bool? i_ = context.Operators.In<CqlDateTime>(g_, h_, null);

			return i_;
		};
		IEnumerable<Observation> d_ = context.Operators.Where<Observation>(b_, c_);
		bool? e_ = context.Operators.Exists<Observation>(d_);

		return e_;
	}

    [CqlDeclaration("Numerator")]
	public bool? Numerator() => 
		__Numerator.Value;

}
