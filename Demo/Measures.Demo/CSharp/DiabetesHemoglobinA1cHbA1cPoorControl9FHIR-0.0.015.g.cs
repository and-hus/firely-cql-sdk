﻿using System;
using Tuples;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using System.Reflection;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;
[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.0.0")]
[CqlLibrary("DiabetesHemoglobinA1cHbA1cPoorControl9FHIR", "0.0.015")]
public class DiabetesHemoglobinA1cHbA1cPoorControl9FHIR_0_0_015
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Annual_Wellness_Visit;
    internal Lazy<CqlValueSet> __Diabetes;
    internal Lazy<CqlValueSet> __Discharged_to_Health_Care_Facility_for_Hospice_Care;
    internal Lazy<CqlValueSet> __Discharged_to_Home_for_Hospice_Care;
    internal Lazy<CqlValueSet> __Encounter_Inpatient;
    internal Lazy<CqlValueSet> __HbA1c_Laboratory_Test;
    internal Lazy<CqlValueSet> __Home_Healthcare_Services;
    internal Lazy<CqlValueSet> __Hospice_care_ambulatory;
    internal Lazy<CqlValueSet> __Office_Visit;
    internal Lazy<CqlValueSet> __Preventive_Care_Services___Established_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Initial_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Telephone_Visits;
    internal Lazy<CqlCode> __Birth_date;
    internal Lazy<CqlCode[]> __LOINC;
    internal Lazy<CqlInterval<CqlDateTime>> __Measurement_Period;
    internal Lazy<Patient> __Patient;
    internal Lazy<IEnumerable<Coding>> __SDE_Ethnicity;
    internal Lazy<IEnumerable<Tuple_CaKghTfWMNOTHSWhifjFZOVYO>> __SDE_Payer;
    internal Lazy<IEnumerable<Coding>> __SDE_Race;
    internal Lazy<CqlCode> __SDE_Sex;
    internal Lazy<IEnumerable<Encounter>> __Telehealth_Services;
    internal Lazy<bool?> __Initial_Population;
    internal Lazy<bool?> __Denominator;
    internal Lazy<Observation> __Most_Recent_HbA1c;
    internal Lazy<bool?> __Has_Most_Recent_HbA1c_Without_Result;
    internal Lazy<bool?> __Has_Most_Recent_Elevated_HbA1c;
    internal Lazy<bool?> __Has_No_Record_Of_HbA1c;
    internal Lazy<bool?> __Numerator;
    internal Lazy<bool?> __Denominator_Exclusions;

    #endregion
    public DiabetesHemoglobinA1cHbA1cPoorControl9FHIR_0_0_015(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_0_001 = new FHIRHelpers_4_0_001(context);
        SupplementalDataElementsFHIR4_2_0_000 = new SupplementalDataElementsFHIR4_2_0_000(context);
        MATGlobalCommonFunctionsFHIR4_6_1_000 = new MATGlobalCommonFunctionsFHIR4_6_1_000(context);
        PalliativeCareFHIR_0_6_000 = new PalliativeCareFHIR_0_6_000(context);
        AdultOutpatientEncountersFHIR4_2_2_000 = new AdultOutpatientEncountersFHIR4_2_2_000(context);
        HospiceFHIR4_2_3_000 = new HospiceFHIR4_2_3_000(context);
        AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000 = new AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000(context);
        CumulativeMedicationDurationFHIR4_1_0_000 = new CumulativeMedicationDurationFHIR4_1_0_000(context);

        __Annual_Wellness_Visit = new Lazy<CqlValueSet>(this.Annual_Wellness_Visit_Value);
        __Diabetes = new Lazy<CqlValueSet>(this.Diabetes_Value);
        __Discharged_to_Health_Care_Facility_for_Hospice_Care = new Lazy<CqlValueSet>(this.Discharged_to_Health_Care_Facility_for_Hospice_Care_Value);
        __Discharged_to_Home_for_Hospice_Care = new Lazy<CqlValueSet>(this.Discharged_to_Home_for_Hospice_Care_Value);
        __Encounter_Inpatient = new Lazy<CqlValueSet>(this.Encounter_Inpatient_Value);
        __HbA1c_Laboratory_Test = new Lazy<CqlValueSet>(this.HbA1c_Laboratory_Test_Value);
        __Home_Healthcare_Services = new Lazy<CqlValueSet>(this.Home_Healthcare_Services_Value);
        __Hospice_care_ambulatory = new Lazy<CqlValueSet>(this.Hospice_care_ambulatory_Value);
        __Office_Visit = new Lazy<CqlValueSet>(this.Office_Visit_Value);
        __Preventive_Care_Services___Established_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services___Established_Office_Visit__18_and_Up_Value);
        __Preventive_Care_Services_Initial_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value);
        __Telephone_Visits = new Lazy<CqlValueSet>(this.Telephone_Visits_Value);
        __Birth_date = new Lazy<CqlCode>(this.Birth_date_Value);
        __LOINC = new Lazy<CqlCode[]>(this.LOINC_Value);
        __Measurement_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Measurement_Period_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __SDE_Ethnicity = new Lazy<IEnumerable<Coding>>(this.SDE_Ethnicity_Value);
        __SDE_Payer = new Lazy<IEnumerable<Tuple_CaKghTfWMNOTHSWhifjFZOVYO>>(this.SDE_Payer_Value);
        __SDE_Race = new Lazy<IEnumerable<Coding>>(this.SDE_Race_Value);
        __SDE_Sex = new Lazy<CqlCode>(this.SDE_Sex_Value);
        __Telehealth_Services = new Lazy<IEnumerable<Encounter>>(this.Telehealth_Services_Value);
        __Initial_Population = new Lazy<bool?>(this.Initial_Population_Value);
        __Denominator = new Lazy<bool?>(this.Denominator_Value);
        __Most_Recent_HbA1c = new Lazy<Observation>(this.Most_Recent_HbA1c_Value);
        __Has_Most_Recent_HbA1c_Without_Result = new Lazy<bool?>(this.Has_Most_Recent_HbA1c_Without_Result_Value);
        __Has_Most_Recent_Elevated_HbA1c = new Lazy<bool?>(this.Has_Most_Recent_Elevated_HbA1c_Value);
        __Has_No_Record_Of_HbA1c = new Lazy<bool?>(this.Has_No_Record_Of_HbA1c_Value);
        __Numerator = new Lazy<bool?>(this.Numerator_Value);
        __Denominator_Exclusions = new Lazy<bool?>(this.Denominator_Exclusions_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_0_001 FHIRHelpers_4_0_001 { get; }
    public SupplementalDataElementsFHIR4_2_0_000 SupplementalDataElementsFHIR4_2_0_000 { get; }
    public MATGlobalCommonFunctionsFHIR4_6_1_000 MATGlobalCommonFunctionsFHIR4_6_1_000 { get; }
    public PalliativeCareFHIR_0_6_000 PalliativeCareFHIR_0_6_000 { get; }
    public AdultOutpatientEncountersFHIR4_2_2_000 AdultOutpatientEncountersFHIR4_2_2_000 { get; }
    public HospiceFHIR4_2_3_000 HospiceFHIR4_2_3_000 { get; }
    public AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000 AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000 { get; }
    public CumulativeMedicationDurationFHIR4_1_0_000 CumulativeMedicationDurationFHIR4_1_0_000 { get; }

    #endregion

	private CqlValueSet Annual_Wellness_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1240", null);

    [CqlDeclaration("Annual Wellness Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1240")]
	public CqlValueSet Annual_Wellness_Visit() => 
		__Annual_Wellness_Visit.Value;

	private CqlValueSet Diabetes_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.103.12.1001", null);

    [CqlDeclaration("Diabetes")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.103.12.1001")]
	public CqlValueSet Diabetes() => 
		__Diabetes.Value;

	private CqlValueSet Discharged_to_Health_Care_Facility_for_Hospice_Care_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.117.1.7.1.207", null);

    [CqlDeclaration("Discharged to Health Care Facility for Hospice Care")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.117.1.7.1.207")]
	public CqlValueSet Discharged_to_Health_Care_Facility_for_Hospice_Care() => 
		__Discharged_to_Health_Care_Facility_for_Hospice_Care.Value;

	private CqlValueSet Discharged_to_Home_for_Hospice_Care_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.117.1.7.1.209", null);

    [CqlDeclaration("Discharged to Home for Hospice Care")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.117.1.7.1.209")]
	public CqlValueSet Discharged_to_Home_for_Hospice_Care() => 
		__Discharged_to_Home_for_Hospice_Care.Value;

	private CqlValueSet Encounter_Inpatient_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307", null);

    [CqlDeclaration("Encounter Inpatient")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307")]
	public CqlValueSet Encounter_Inpatient() => 
		__Encounter_Inpatient.Value;

	private CqlValueSet HbA1c_Laboratory_Test_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.198.12.1013", null);

    [CqlDeclaration("HbA1c Laboratory Test")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.198.12.1013")]
	public CqlValueSet HbA1c_Laboratory_Test() => 
		__HbA1c_Laboratory_Test.Value;

	private CqlValueSet Home_Healthcare_Services_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016", null);

    [CqlDeclaration("Home Healthcare Services")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016")]
	public CqlValueSet Home_Healthcare_Services() => 
		__Home_Healthcare_Services.Value;

	private CqlValueSet Hospice_care_ambulatory_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113762.1.4.1108.15", null);

    [CqlDeclaration("Hospice care ambulatory")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113762.1.4.1108.15")]
	public CqlValueSet Hospice_care_ambulatory() => 
		__Hospice_care_ambulatory.Value;

	private CqlValueSet Office_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001", null);

    [CqlDeclaration("Office Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001")]
	public CqlValueSet Office_Visit() => 
		__Office_Visit.Value;

	private CqlValueSet Preventive_Care_Services___Established_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025", null);

    [CqlDeclaration("Preventive Care Services - Established Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025")]
	public CqlValueSet Preventive_Care_Services___Established_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services___Established_Office_Visit__18_and_Up.Value;

	private CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023", null);

    [CqlDeclaration("Preventive Care Services-Initial Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023")]
	public CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services_Initial_Office_Visit__18_and_Up.Value;

	private CqlValueSet Telephone_Visits_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080", null);

    [CqlDeclaration("Telephone Visits")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080")]
	public CqlValueSet Telephone_Visits() => 
		__Telephone_Visits.Value;

	private CqlCode Birth_date_Value() => 
		new CqlCode("21112-8", "http://loinc.org", null, null);

    [CqlDeclaration("Birth date")]
	public CqlCode Birth_date() => 
		__Birth_date.Value;

	private CqlCode[] LOINC_Value()
	{
		var a_ = new CqlCode[]
		{
			new CqlCode("21112-8", "http://loinc.org", null, null),
		};

		return a_;
	}

    [CqlDeclaration("LOINC")]
	public CqlCode[] LOINC() => 
		__LOINC.Value;

	private CqlInterval<CqlDateTime> Measurement_Period_Value()
	{
		var a_ = context.ResolveParameter("DiabetesHemoglobinA1cHbA1cPoorControl9FHIR-0.0.015", "Measurement Period", null);

		return (CqlInterval<CqlDateTime>)a_;
	}

    [CqlDeclaration("Measurement Period")]
	public CqlInterval<CqlDateTime> Measurement_Period() => 
		__Measurement_Period.Value;

	private Patient Patient_Value()
	{
		var a_ = context.Operators.RetrieveByValueSet<Patient>(null, null);
		var b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient() => 
		__Patient.Value;

	private IEnumerable<Coding> SDE_Ethnicity_Value()
	{
		var a_ = SupplementalDataElementsFHIR4_2_0_000.SDE_Ethnicity();

		return a_;
	}

    [CqlDeclaration("SDE Ethnicity")]
	public IEnumerable<Coding> SDE_Ethnicity() => 
		__SDE_Ethnicity.Value;

	private IEnumerable<Tuple_CaKghTfWMNOTHSWhifjFZOVYO> SDE_Payer_Value()
	{
		var a_ = SupplementalDataElementsFHIR4_2_0_000.SDE_Payer();

		return a_;
	}

    [CqlDeclaration("SDE Payer")]
	public IEnumerable<Tuple_CaKghTfWMNOTHSWhifjFZOVYO> SDE_Payer() => 
		__SDE_Payer.Value;

	private IEnumerable<Coding> SDE_Race_Value()
	{
		var a_ = SupplementalDataElementsFHIR4_2_0_000.SDE_Race();

		return a_;
	}

    [CqlDeclaration("SDE Race")]
	public IEnumerable<Coding> SDE_Race() => 
		__SDE_Race.Value;

	private CqlCode SDE_Sex_Value()
	{
		var a_ = SupplementalDataElementsFHIR4_2_0_000.SDE_Sex();

		return a_;
	}

    [CqlDeclaration("SDE Sex")]
	public CqlCode SDE_Sex() => 
		__SDE_Sex.Value;

	private IEnumerable<Encounter> Telehealth_Services_Value()
	{
		var a_ = this.Telephone_Visits();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		bool? c_(Encounter TelehealthEncounter)
		{
			var e_ = TelehealthEncounter?.StatusElement;
			var f_ = FHIRHelpers_4_0_001.ToString(e_);
			var g_ = context.Operators.Equal(f_, "finished");
			var h_ = this.Measurement_Period();
			var i_ = TelehealthEncounter?.Period;
			var j_ = MATGlobalCommonFunctionsFHIR4_6_1_000.Normalize_Interval((i_ as object));
			var k_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(h_, j_, null);
			var l_ = context.Operators.And(g_, k_);

			return l_;
		};
		var d_ = context.Operators.Where<Encounter>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Telehealth Services")]
	public IEnumerable<Encounter> Telehealth_Services() => 
		__Telehealth_Services.Value;

	private bool? Initial_Population_Value()
	{
		var a_ = this.Patient();
		var b_ = context.Operators.ConvertStringToDate(a_?.BirthDateElement?.Value);
		var c_ = this.Measurement_Period();
		var d_ = context.Operators.Start(c_);
		var e_ = context.Operators.DateFrom(d_);
		var f_ = context.Operators.CalculateAgeAt(b_, e_, "year");
		var g_ = context.Operators.Interval(18, 75, true, false);
		var h_ = context.Operators.In<int?>(f_, g_, null);
		var i_ = AdultOutpatientEncountersFHIR4_2_2_000.Qualifying_Encounters();
		var j_ = this.Telehealth_Services();
		var k_ = context.Operators.Union<Encounter>(i_, j_);
		var l_ = context.Operators.Exists<Encounter>(k_);
		var m_ = context.Operators.And(h_, l_);
		var n_ = this.Diabetes();
		var o_ = context.Operators.RetrieveByValueSet<Condition>(n_, null);
		bool? p_(Condition Diabetes)
		{
			var t_ = MATGlobalCommonFunctionsFHIR4_6_1_000.Prevalence_Period(Diabetes);
			var u_ = this.Measurement_Period();
			var v_ = context.Operators.Overlaps(t_, u_, null);

			return v_;
		};
		var q_ = context.Operators.Where<Condition>(o_, p_);
		var r_ = context.Operators.Exists<Condition>(q_);
		var s_ = context.Operators.And(m_, r_);

		return s_;
	}

    [CqlDeclaration("Initial Population")]
	public bool? Initial_Population() => 
		__Initial_Population.Value;

	private bool? Denominator_Value()
	{
		var a_ = this.Initial_Population();

		return a_;
	}

    [CqlDeclaration("Denominator")]
	public bool? Denominator() => 
		__Denominator.Value;

	private Observation Most_Recent_HbA1c_Value()
	{
		var a_ = this.HbA1c_Laboratory_Test();
		var b_ = context.Operators.RetrieveByValueSet<Observation>(a_, null);
		bool? c_(Observation RecentHbA1c)
		{
			var h_ = RecentHbA1c?.StatusElement;
			var i_ = FHIRHelpers_4_0_001.ToString(h_);
			var j_ = new string[]
			{
				"final",
				"amended",
				"corrected",
			};
			var k_ = context.Operators.In<string>(i_, (j_ as IEnumerable<string>));
			var l_ = RecentHbA1c?.Effective;
			var m_ = MATGlobalCommonFunctionsFHIR4_6_1_000.Latest(l_);
			var n_ = this.Measurement_Period();
			var o_ = context.Operators.In<CqlDateTime>(m_, n_, null);
			var p_ = context.Operators.And(k_, o_);

			return p_;
		};
		var d_ = context.Operators.Where<Observation>(b_, c_);
		object e_(Observation @this)
		{
			var q_ = @this?.Effective;
			var r_ = MATGlobalCommonFunctionsFHIR4_6_1_000.Normalize_Interval(q_);
			var s_ = context.Operators.Start(r_);

			return s_;
		};
		var f_ = context.Operators.SortBy<Observation>(d_, e_, System.ComponentModel.ListSortDirection.Ascending);
		var g_ = context.Operators.Last<Observation>(f_);

		return g_;
	}

    [CqlDeclaration("Most Recent HbA1c")]
	public Observation Most_Recent_HbA1c() => 
		__Most_Recent_HbA1c.Value;

	private bool? Has_Most_Recent_HbA1c_Without_Result_Value()
	{
		var a_ = this.Most_Recent_HbA1c();
		var b_ = context.Operators.Not((bool?)(a_ is null));
		var d_ = context.Operators.And(b_, (bool?)(a_?.Value is null));

		return d_;
	}

    [CqlDeclaration("Has Most Recent HbA1c Without Result")]
	public bool? Has_Most_Recent_HbA1c_Without_Result() => 
		__Has_Most_Recent_HbA1c_Without_Result.Value;

	private bool? Has_Most_Recent_Elevated_HbA1c_Value()
	{
		var a_ = this.Most_Recent_HbA1c();
		var b_ = FHIRHelpers_4_0_001.ToQuantity((a_?.Value as Quantity));
		var c_ = context.Operators.Quantity(9m, "%");
		var d_ = context.Operators.Greater(b_, c_);

		return d_;
	}

    [CqlDeclaration("Has Most Recent Elevated HbA1c")]
	public bool? Has_Most_Recent_Elevated_HbA1c() => 
		__Has_Most_Recent_Elevated_HbA1c.Value;

	private bool? Has_No_Record_Of_HbA1c_Value()
	{
		var a_ = this.HbA1c_Laboratory_Test();
		var b_ = context.Operators.RetrieveByValueSet<Observation>(a_, null);
		bool? c_(Observation NoHbA1c)
		{
			var g_ = NoHbA1c?.StatusElement;
			var h_ = FHIRHelpers_4_0_001.ToString(g_);
			var i_ = new string[]
			{
				"final",
				"amended",
				"corrected",
			};
			var j_ = context.Operators.In<string>(h_, (i_ as IEnumerable<string>));
			var k_ = NoHbA1c?.Effective;
			var l_ = MATGlobalCommonFunctionsFHIR4_6_1_000.Latest(k_);
			var m_ = this.Measurement_Period();
			var n_ = context.Operators.In<CqlDateTime>(l_, m_, null);
			var o_ = context.Operators.And(j_, n_);

			return o_;
		};
		var d_ = context.Operators.Where<Observation>(b_, c_);
		var e_ = context.Operators.Exists<Observation>(d_);
		var f_ = context.Operators.Not(e_);

		return f_;
	}

    [CqlDeclaration("Has No Record Of HbA1c")]
	public bool? Has_No_Record_Of_HbA1c() => 
		__Has_No_Record_Of_HbA1c.Value;

	private bool? Numerator_Value()
	{
		var a_ = this.Has_Most_Recent_HbA1c_Without_Result();
		var b_ = this.Has_Most_Recent_Elevated_HbA1c();
		var c_ = context.Operators.Or(a_, b_);
		var d_ = this.Has_No_Record_Of_HbA1c();
		var e_ = context.Operators.Or(c_, d_);

		return e_;
	}

    [CqlDeclaration("Numerator")]
	public bool? Numerator() => 
		__Numerator.Value;

	private bool? Denominator_Exclusions_Value()
	{
		var a_ = HospiceFHIR4_2_3_000.Has_Hospice();
		var b_ = AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000.Advanced_Illness_and_Frailty_Exclusion_Not_Including_Over_Age_80();
		var c_ = context.Operators.Or(a_, b_);
		var d_ = this.Patient();
		var e_ = context.Operators.ConvertStringToDate(d_?.BirthDateElement?.Value);
		var f_ = this.Measurement_Period();
		var g_ = context.Operators.Start(f_);
		var h_ = context.Operators.DateFrom(g_);
		var i_ = context.Operators.CalculateAgeAt(e_, h_, "year");
		var j_ = context.Operators.GreaterOrEqual(i_, 65);
		var k_ = AdvancedIllnessandFrailtyExclusionECQMFHIR4_5_17_000.Has_Long_Term_Care_Periods_Longer_Than_90_Consecutive_Days();
		var l_ = context.Operators.And(j_, k_);
		var m_ = context.Operators.Or(c_, l_);
		var n_ = PalliativeCareFHIR_0_6_000.Palliative_Care_in_the_Measurement_Period();
		var o_ = context.Operators.Or(m_, n_);

		return o_;
	}

    [CqlDeclaration("Denominator Exclusions")]
	public bool? Denominator_Exclusions() => 
		__Denominator_Exclusions.Value;

}
