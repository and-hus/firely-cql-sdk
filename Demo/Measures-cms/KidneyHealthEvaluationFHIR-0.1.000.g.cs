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
[CqlLibrary("KidneyHealthEvaluationFHIR", "0.1.000")]
public class KidneyHealthEvaluationFHIR_0_1_000
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Acute_Inpatient;
    internal Lazy<CqlValueSet> __Annual_Wellness_Visit;
    internal Lazy<CqlValueSet> __Chronic_Kidney_Disease__Stage_5;
    internal Lazy<CqlValueSet> __Diabetes;
    internal Lazy<CqlValueSet> __Encounter_Inpatient;
    internal Lazy<CqlValueSet> __End_Stage_Renal_Disease;
    internal Lazy<CqlValueSet> __Estimated_Glomerular_Filtration_Rate;
    internal Lazy<CqlValueSet> __Home_Healthcare_Services;
    internal Lazy<CqlValueSet> __Hospice_Care_Ambulatory;
    internal Lazy<CqlValueSet> __Office_Visit;
    internal Lazy<CqlValueSet> __Outpatient_Consultation;
    internal Lazy<CqlValueSet> __Palliative_or_Hospice_Care;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Established_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Initial_Office_Visit__18_and_Up;
    internal Lazy<CqlValueSet> __Telephone_Visits;
    internal Lazy<CqlValueSet> __Urine_Albumin_Creatinine_Ratio;
    internal Lazy<CqlCode> __Discharge_to_healthcare_facility_for_hospice_care__procedure_;
    internal Lazy<CqlCode> __Discharge_to_home_for_hospice_care__procedure_;
    internal Lazy<CqlCode> __AMB;
    internal Lazy<CqlCode> __active;
    internal Lazy<CqlCode[]> __SNOMEDCT;
    internal Lazy<CqlCode[]> __ActCode;
    internal Lazy<CqlCode[]> __ConditionClinicalStatusCodes;
    internal Lazy<CqlInterval<CqlDateTime>> __Measurement_Period;
    internal Lazy<Patient> __Patient;
    internal Lazy<bool?> __Has_Active_Diabetes_Overlaps_Measurement_Period;
    internal Lazy<bool?> __Has_Outpatient_Visit_During_Measurement_Period;
    internal Lazy<bool?> __Initial_Population;
    internal Lazy<bool?> __Denominator;
    internal Lazy<IEnumerable<Condition>> __Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period;
    internal Lazy<bool?> __Denominator_Exclusions;
    internal Lazy<bool?> __Has_Kidney_Panel_Performed_During_Measurement_Period;
    internal Lazy<bool?> __Numerator;
    internal Lazy<Tuple_DMgHTLENEHBHWJISQgKZGZVMB> __SDE_Ethnicity;
    internal Lazy<IEnumerable<Tuple_GDKRbfOIHhLGieQSVDEMIaDPX>> __SDE_Payer;
    internal Lazy<Tuple_DMgHTLENEHBHWJISQgKZGZVMB> __SDE_Race;
    internal Lazy<CqlCode> __SDE_Sex;

    #endregion
    public KidneyHealthEvaluationFHIR_0_1_000(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_3_000 = new FHIRHelpers_4_3_000(context);
        SupplementalDataElements_3_4_000 = new SupplementalDataElements_3_4_000(context);
        CQMCommon_2_0_000 = new CQMCommon_2_0_000(context);
        Hospice_6_9_000 = new Hospice_6_9_000(context);
        PalliativeCare_1_9_000 = new PalliativeCare_1_9_000(context);
        QICoreCommon_2_0_000 = new QICoreCommon_2_0_000(context);

        __Acute_Inpatient = new Lazy<CqlValueSet>(this.Acute_Inpatient_Value);
        __Annual_Wellness_Visit = new Lazy<CqlValueSet>(this.Annual_Wellness_Visit_Value);
        __Chronic_Kidney_Disease__Stage_5 = new Lazy<CqlValueSet>(this.Chronic_Kidney_Disease__Stage_5_Value);
        __Diabetes = new Lazy<CqlValueSet>(this.Diabetes_Value);
        __Encounter_Inpatient = new Lazy<CqlValueSet>(this.Encounter_Inpatient_Value);
        __End_Stage_Renal_Disease = new Lazy<CqlValueSet>(this.End_Stage_Renal_Disease_Value);
        __Estimated_Glomerular_Filtration_Rate = new Lazy<CqlValueSet>(this.Estimated_Glomerular_Filtration_Rate_Value);
        __Home_Healthcare_Services = new Lazy<CqlValueSet>(this.Home_Healthcare_Services_Value);
        __Hospice_Care_Ambulatory = new Lazy<CqlValueSet>(this.Hospice_Care_Ambulatory_Value);
        __Office_Visit = new Lazy<CqlValueSet>(this.Office_Visit_Value);
        __Outpatient_Consultation = new Lazy<CqlValueSet>(this.Outpatient_Consultation_Value);
        __Palliative_or_Hospice_Care = new Lazy<CqlValueSet>(this.Palliative_or_Hospice_Care_Value);
        __Preventive_Care_Services_Established_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Established_Office_Visit__18_and_Up_Value);
        __Preventive_Care_Services_Initial_Office_Visit__18_and_Up = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value);
        __Telephone_Visits = new Lazy<CqlValueSet>(this.Telephone_Visits_Value);
        __Urine_Albumin_Creatinine_Ratio = new Lazy<CqlValueSet>(this.Urine_Albumin_Creatinine_Ratio_Value);
        __Discharge_to_healthcare_facility_for_hospice_care__procedure_ = new Lazy<CqlCode>(this.Discharge_to_healthcare_facility_for_hospice_care__procedure__Value);
        __Discharge_to_home_for_hospice_care__procedure_ = new Lazy<CqlCode>(this.Discharge_to_home_for_hospice_care__procedure__Value);
        __AMB = new Lazy<CqlCode>(this.AMB_Value);
        __active = new Lazy<CqlCode>(this.active_Value);
        __SNOMEDCT = new Lazy<CqlCode[]>(this.SNOMEDCT_Value);
        __ActCode = new Lazy<CqlCode[]>(this.ActCode_Value);
        __ConditionClinicalStatusCodes = new Lazy<CqlCode[]>(this.ConditionClinicalStatusCodes_Value);
        __Measurement_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Measurement_Period_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __Has_Active_Diabetes_Overlaps_Measurement_Period = new Lazy<bool?>(this.Has_Active_Diabetes_Overlaps_Measurement_Period_Value);
        __Has_Outpatient_Visit_During_Measurement_Period = new Lazy<bool?>(this.Has_Outpatient_Visit_During_Measurement_Period_Value);
        __Initial_Population = new Lazy<bool?>(this.Initial_Population_Value);
        __Denominator = new Lazy<bool?>(this.Denominator_Value);
        __Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period = new Lazy<IEnumerable<Condition>>(this.Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period_Value);
        __Denominator_Exclusions = new Lazy<bool?>(this.Denominator_Exclusions_Value);
        __Has_Kidney_Panel_Performed_During_Measurement_Period = new Lazy<bool?>(this.Has_Kidney_Panel_Performed_During_Measurement_Period_Value);
        __Numerator = new Lazy<bool?>(this.Numerator_Value);
        __SDE_Ethnicity = new Lazy<Tuple_DMgHTLENEHBHWJISQgKZGZVMB>(this.SDE_Ethnicity_Value);
        __SDE_Payer = new Lazy<IEnumerable<Tuple_GDKRbfOIHhLGieQSVDEMIaDPX>>(this.SDE_Payer_Value);
        __SDE_Race = new Lazy<Tuple_DMgHTLENEHBHWJISQgKZGZVMB>(this.SDE_Race_Value);
        __SDE_Sex = new Lazy<CqlCode>(this.SDE_Sex_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_3_000 FHIRHelpers_4_3_000 { get; }
    public SupplementalDataElements_3_4_000 SupplementalDataElements_3_4_000 { get; }
    public CQMCommon_2_0_000 CQMCommon_2_0_000 { get; }
    public Hospice_6_9_000 Hospice_6_9_000 { get; }
    public PalliativeCare_1_9_000 PalliativeCare_1_9_000 { get; }
    public QICoreCommon_2_0_000 QICoreCommon_2_0_000 { get; }

    #endregion

	private CqlValueSet Acute_Inpatient_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1083", null);

    [CqlDeclaration("Acute Inpatient")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1083")]
	public CqlValueSet Acute_Inpatient() => 
		__Acute_Inpatient.Value;

	private CqlValueSet Annual_Wellness_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1240", null);

    [CqlDeclaration("Annual Wellness Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1240")]
	public CqlValueSet Annual_Wellness_Visit() => 
		__Annual_Wellness_Visit.Value;

	private CqlValueSet Chronic_Kidney_Disease__Stage_5_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1002", null);

    [CqlDeclaration("Chronic Kidney Disease, Stage 5")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1002")]
	public CqlValueSet Chronic_Kidney_Disease__Stage_5() => 
		__Chronic_Kidney_Disease__Stage_5.Value;

	private CqlValueSet Diabetes_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.103.12.1001", null);

    [CqlDeclaration("Diabetes")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.103.12.1001")]
	public CqlValueSet Diabetes() => 
		__Diabetes.Value;

	private CqlValueSet Encounter_Inpatient_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307", null);

    [CqlDeclaration("Encounter Inpatient")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307")]
	public CqlValueSet Encounter_Inpatient() => 
		__Encounter_Inpatient.Value;

	private CqlValueSet End_Stage_Renal_Disease_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.353", null);

    [CqlDeclaration("End Stage Renal Disease")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.353")]
	public CqlValueSet End_Stage_Renal_Disease() => 
		__End_Stage_Renal_Disease.Value;

	private CqlValueSet Estimated_Glomerular_Filtration_Rate_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.6929.3.1000", null);

    [CqlDeclaration("Estimated Glomerular Filtration Rate")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.6929.3.1000")]
	public CqlValueSet Estimated_Glomerular_Filtration_Rate() => 
		__Estimated_Glomerular_Filtration_Rate.Value;

	private CqlValueSet Home_Healthcare_Services_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016", null);

    [CqlDeclaration("Home Healthcare Services")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016")]
	public CqlValueSet Home_Healthcare_Services() => 
		__Home_Healthcare_Services.Value;

	private CqlValueSet Hospice_Care_Ambulatory_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1584", null);

    [CqlDeclaration("Hospice Care Ambulatory")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1584")]
	public CqlValueSet Hospice_Care_Ambulatory() => 
		__Hospice_Care_Ambulatory.Value;

	private CqlValueSet Office_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001", null);

    [CqlDeclaration("Office Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001")]
	public CqlValueSet Office_Visit() => 
		__Office_Visit.Value;

	private CqlValueSet Outpatient_Consultation_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1008", null);

    [CqlDeclaration("Outpatient Consultation")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1008")]
	public CqlValueSet Outpatient_Consultation() => 
		__Outpatient_Consultation.Value;

	private CqlValueSet Palliative_or_Hospice_Care_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.600.1.1579", null);

    [CqlDeclaration("Palliative or Hospice Care")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.600.1.1579")]
	public CqlValueSet Palliative_or_Hospice_Care() => 
		__Palliative_or_Hospice_Care.Value;

	private CqlValueSet Preventive_Care_Services_Established_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025", null);

    [CqlDeclaration("Preventive Care Services Established Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1025")]
	public CqlValueSet Preventive_Care_Services_Established_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services_Established_Office_Visit__18_and_Up.Value;

	private CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023", null);

    [CqlDeclaration("Preventive Care Services Initial Office Visit, 18 and Up")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1023")]
	public CqlValueSet Preventive_Care_Services_Initial_Office_Visit__18_and_Up() => 
		__Preventive_Care_Services_Initial_Office_Visit__18_and_Up.Value;

	private CqlValueSet Telephone_Visits_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080", null);

    [CqlDeclaration("Telephone Visits")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080")]
	public CqlValueSet Telephone_Visits() => 
		__Telephone_Visits.Value;

	private CqlValueSet Urine_Albumin_Creatinine_Ratio_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.6929.3.1007", null);

    [CqlDeclaration("Urine Albumin Creatinine Ratio")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.6929.3.1007")]
	public CqlValueSet Urine_Albumin_Creatinine_Ratio() => 
		__Urine_Albumin_Creatinine_Ratio.Value;

	private CqlCode Discharge_to_healthcare_facility_for_hospice_care__procedure__Value() => 
		new CqlCode("428371000124100", "http://snomed.info/sct", null, null);

    [CqlDeclaration("Discharge to healthcare facility for hospice care (procedure)")]
	public CqlCode Discharge_to_healthcare_facility_for_hospice_care__procedure_() => 
		__Discharge_to_healthcare_facility_for_hospice_care__procedure_.Value;

	private CqlCode Discharge_to_home_for_hospice_care__procedure__Value() => 
		new CqlCode("428361000124107", "http://snomed.info/sct", null, null);

    [CqlDeclaration("Discharge to home for hospice care (procedure)")]
	public CqlCode Discharge_to_home_for_hospice_care__procedure_() => 
		__Discharge_to_home_for_hospice_care__procedure_.Value;

	private CqlCode AMB_Value() => 
		new CqlCode("AMB", "http://terminology.hl7.org/CodeSystem/v3-ActCode", null, null);

    [CqlDeclaration("AMB")]
	public CqlCode AMB() => 
		__AMB.Value;

	private CqlCode active_Value() => 
		new CqlCode("active", "http://terminology.hl7.org/CodeSystem/condition-clinical", null, null);

    [CqlDeclaration("active")]
	public CqlCode active() => 
		__active.Value;

	private CqlCode[] SNOMEDCT_Value()
	{
		CqlCode[] a_ = new CqlCode[]
		{
			new CqlCode("428371000124100", "http://snomed.info/sct", null, null),
			new CqlCode("428361000124107", "http://snomed.info/sct", null, null),
		};

		return a_;
	}

    [CqlDeclaration("SNOMEDCT")]
	public CqlCode[] SNOMEDCT() => 
		__SNOMEDCT.Value;

	private CqlCode[] ActCode_Value()
	{
		CqlCode[] a_ = new CqlCode[]
		{
			new CqlCode("AMB", "http://terminology.hl7.org/CodeSystem/v3-ActCode", null, null),
		};

		return a_;
	}

    [CqlDeclaration("ActCode")]
	public CqlCode[] ActCode() => 
		__ActCode.Value;

	private CqlCode[] ConditionClinicalStatusCodes_Value()
	{
		CqlCode[] a_ = new CqlCode[]
		{
			new CqlCode("active", "http://terminology.hl7.org/CodeSystem/condition-clinical", null, null),
		};

		return a_;
	}

    [CqlDeclaration("ConditionClinicalStatusCodes")]
	public CqlCode[] ConditionClinicalStatusCodes() => 
		__ConditionClinicalStatusCodes.Value;

	private CqlInterval<CqlDateTime> Measurement_Period_Value()
	{
		CqlDateTime a_ = context.Operators.DateTime(2025, 1, 1, 0, 0, 0, 0, default);
		CqlDateTime b_ = context.Operators.DateTime(2026, 1, 1, 0, 0, 0, 0, default);
		CqlInterval<CqlDateTime> c_ = context.Operators.Interval(a_, b_, true, false);
		object d_ = context.ResolveParameter("KidneyHealthEvaluationFHIR-0.1.000", "Measurement Period", c_);

		return (CqlInterval<CqlDateTime>)d_;
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

	private bool? Has_Active_Diabetes_Overlaps_Measurement_Period_Value()
	{
		CqlValueSet a_ = this.Diabetes();
		IEnumerable<Condition> b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		bool? c_(Condition Diabetes)
		{
			CqlInterval<CqlDateTime> f_ = QICoreCommon_2_0_000.ToPrevalenceInterval(Diabetes);
			CqlInterval<CqlDateTime> g_ = this.Measurement_Period();
			bool? h_ = context.Operators.Overlaps(f_, g_, null);
			CqlConcept i_ = FHIRHelpers_4_3_000.ToConcept(Diabetes?.ClinicalStatus);
			CqlCode j_ = this.active();
			CqlConcept k_ = context.Operators.ConvertCodeToConcept(j_);
			bool? l_ = context.Operators.Equivalent(i_, k_);
			bool? m_ = context.Operators.And(h_, l_);

			return m_;
		};
		IEnumerable<Condition> d_ = context.Operators.Where<Condition>(b_, c_);
		bool? e_ = context.Operators.Exists<Condition>(d_);

		return e_;
	}

    [CqlDeclaration("Has Active Diabetes Overlaps Measurement Period")]
	public bool? Has_Active_Diabetes_Overlaps_Measurement_Period() => 
		__Has_Active_Diabetes_Overlaps_Measurement_Period.Value;

	private bool? Has_Outpatient_Visit_During_Measurement_Period_Value()
	{
		CqlValueSet a_ = this.Annual_Wellness_Visit();
		IEnumerable<Encounter> b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		CqlValueSet c_ = this.Home_Healthcare_Services();
		IEnumerable<Encounter> d_ = context.Operators.RetrieveByValueSet<Encounter>(c_, null);
		IEnumerable<Encounter> e_ = context.Operators.ListUnion<Encounter>(b_, d_);
		CqlValueSet f_ = this.Office_Visit();
		IEnumerable<Encounter> g_ = context.Operators.RetrieveByValueSet<Encounter>(f_, null);
		CqlValueSet h_ = this.Outpatient_Consultation();
		IEnumerable<Encounter> i_ = context.Operators.RetrieveByValueSet<Encounter>(h_, null);
		IEnumerable<Encounter> j_ = context.Operators.ListUnion<Encounter>(g_, i_);
		IEnumerable<Encounter> k_ = context.Operators.ListUnion<Encounter>(e_, j_);
		CqlValueSet l_ = this.Preventive_Care_Services_Established_Office_Visit__18_and_Up();
		IEnumerable<Encounter> m_ = context.Operators.RetrieveByValueSet<Encounter>(l_, null);
		CqlValueSet n_ = this.Preventive_Care_Services_Initial_Office_Visit__18_and_Up();
		IEnumerable<Encounter> o_ = context.Operators.RetrieveByValueSet<Encounter>(n_, null);
		IEnumerable<Encounter> p_ = context.Operators.ListUnion<Encounter>(m_, o_);
		IEnumerable<Encounter> q_ = context.Operators.ListUnion<Encounter>(k_, p_);
		CqlValueSet r_ = this.Telephone_Visits();
		IEnumerable<Encounter> s_ = context.Operators.RetrieveByValueSet<Encounter>(r_, null);
		IEnumerable<Encounter> t_ = context.Operators.ListUnion<Encounter>(q_, s_);
		bool? u_(Encounter ValidEncounter)
		{
			CqlInterval<CqlDateTime> x_ = this.Measurement_Period();
			CqlInterval<CqlDateTime> y_ = FHIRHelpers_4_3_000.ToInterval(ValidEncounter?.Period);
			bool? z_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(x_, y_, null);
			Code<Encounter.EncounterStatus> aa_ = context.Operators.Convert<Code<Encounter.EncounterStatus>>(ValidEncounter?.StatusElement?.Value);
			bool? ab_ = context.Operators.Equal(aa_, "finished");
			bool? ac_ = context.Operators.And(z_, ab_);

			return ac_;
		};
		IEnumerable<Encounter> v_ = context.Operators.Where<Encounter>(t_, u_);
		bool? w_ = context.Operators.Exists<Encounter>(v_);

		return w_;
	}

    [CqlDeclaration("Has Outpatient Visit During Measurement Period")]
	public bool? Has_Outpatient_Visit_During_Measurement_Period() => 
		__Has_Outpatient_Visit_During_Measurement_Period.Value;

	private bool? Initial_Population_Value()
	{
		Patient a_ = this.Patient();
		CqlDate b_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		CqlInterval<CqlDateTime> c_ = this.Measurement_Period();
		CqlDateTime d_ = context.Operators.Start(c_);
		CqlDate e_ = context.Operators.DateFrom(d_);
		int? f_ = context.Operators.CalculateAgeAt(b_, e_, "year");
		CqlInterval<int?> g_ = context.Operators.Interval(18, 85, true, true);
		bool? h_ = context.Operators.In<int?>(f_, g_, null);
		bool? i_ = this.Has_Active_Diabetes_Overlaps_Measurement_Period();
		bool? j_ = context.Operators.And(h_, i_);
		bool? k_ = this.Has_Outpatient_Visit_During_Measurement_Period();
		bool? l_ = context.Operators.And(j_, k_);

		return l_;
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

	private IEnumerable<Condition> Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period_Value()
	{
		CqlValueSet a_ = this.Chronic_Kidney_Disease__Stage_5();
		IEnumerable<Condition> b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		CqlValueSet c_ = this.End_Stage_Renal_Disease();
		IEnumerable<Condition> d_ = context.Operators.RetrieveByValueSet<Condition>(c_, null);
		IEnumerable<Condition> e_ = context.Operators.ListUnion<Condition>(b_, d_);
		bool? f_(Condition CKDOrESRD)
		{
			CqlInterval<CqlDateTime> h_ = QICoreCommon_2_0_000.ToPrevalenceInterval(CKDOrESRD);
			CqlInterval<CqlDateTime> i_ = this.Measurement_Period();
			bool? j_ = context.Operators.Overlaps(h_, i_, null);
			CqlConcept k_ = FHIRHelpers_4_3_000.ToConcept(CKDOrESRD?.ClinicalStatus);
			CqlCode l_ = this.active();
			CqlConcept m_ = context.Operators.ConvertCodeToConcept(l_);
			bool? n_ = context.Operators.Equivalent(k_, m_);
			bool? o_ = context.Operators.And(j_, n_);

			return o_;
		};
		IEnumerable<Condition> g_ = context.Operators.Where<Condition>(e_, f_);

		return g_;
	}

    [CqlDeclaration("Has CKD Stage 5 or ESRD Diagnosis Overlaps Measurement Period")]
	public IEnumerable<Condition> Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period() => 
		__Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period.Value;

	private bool? Denominator_Exclusions_Value()
	{
		IEnumerable<Condition> a_ = this.Has_CKD_Stage_5_or_ESRD_Diagnosis_Overlaps_Measurement_Period();
		bool? b_ = context.Operators.Exists<Condition>(a_);
		bool? c_ = Hospice_6_9_000.Has_Hospice_Services();
		bool? d_ = context.Operators.Or(b_, c_);
		bool? e_ = PalliativeCare_1_9_000.Has_Palliative_Care_in_the_Measurement_Period();
		bool? f_ = context.Operators.Or(d_, e_);

		return f_;
	}

    [CqlDeclaration("Denominator Exclusions")]
	public bool? Denominator_Exclusions() => 
		__Denominator_Exclusions.Value;

	private bool? Has_Kidney_Panel_Performed_During_Measurement_Period_Value()
	{
		CqlValueSet a_ = this.Estimated_Glomerular_Filtration_Rate();
		IEnumerable<Observation> b_ = context.Operators.RetrieveByValueSet<Observation>(a_, null);
		bool? c_(Observation eGFRTest)
		{
			CqlInterval<CqlDateTime> l_ = this.Measurement_Period();
			object m_ = FHIRHelpers_4_3_000.ToValue(eGFRTest?.Effective);
			CqlInterval<CqlDateTime> n_ = QICoreCommon_2_0_000.ToInterval(m_);
			bool? o_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(l_, n_, null);
			object p_ = FHIRHelpers_4_3_000.ToValue(eGFRTest?.Value);
			bool? q_ = context.Operators.Not((bool?)(p_ is null));
			bool? r_ = context.Operators.And(o_, q_);
			Code<ObservationStatus> s_ = context.Operators.Convert<Code<ObservationStatus>>(eGFRTest?.StatusElement?.Value);
			string t_ = context.Operators.Convert<string>(s_);
			string[] u_ = new string[]
			{
				"final",
				"amended",
				"corrected",
			};
			bool? v_ = context.Operators.In<string>(t_, (u_ as IEnumerable<string>));
			bool? w_ = context.Operators.And(r_, v_);

			return w_;
		};
		IEnumerable<Observation> d_ = context.Operators.Where<Observation>(b_, c_);
		bool? e_ = context.Operators.Exists<Observation>(d_);
		CqlValueSet f_ = this.Urine_Albumin_Creatinine_Ratio();
		IEnumerable<Observation> g_ = context.Operators.RetrieveByValueSet<Observation>(f_, null);
		bool? h_(Observation uACRTest)
		{
			CqlInterval<CqlDateTime> x_ = this.Measurement_Period();
			object y_ = FHIRHelpers_4_3_000.ToValue(uACRTest?.Effective);
			CqlInterval<CqlDateTime> z_ = QICoreCommon_2_0_000.ToInterval(y_);
			bool? aa_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(x_, z_, null);
			object ab_ = FHIRHelpers_4_3_000.ToValue(uACRTest?.Value);
			bool? ac_ = context.Operators.Not((bool?)(ab_ is null));
			bool? ad_ = context.Operators.And(aa_, ac_);
			Code<ObservationStatus> ae_ = context.Operators.Convert<Code<ObservationStatus>>(uACRTest?.StatusElement?.Value);
			string af_ = context.Operators.Convert<string>(ae_);
			string[] ag_ = new string[]
			{
				"final",
				"amended",
				"corrected",
			};
			bool? ah_ = context.Operators.In<string>(af_, (ag_ as IEnumerable<string>));
			bool? ai_ = context.Operators.And(ad_, ah_);

			return ai_;
		};
		IEnumerable<Observation> i_ = context.Operators.Where<Observation>(g_, h_);
		bool? j_ = context.Operators.Exists<Observation>(i_);
		bool? k_ = context.Operators.And(e_, j_);

		return k_;
	}

    [CqlDeclaration("Has Kidney Panel Performed During Measurement Period")]
	public bool? Has_Kidney_Panel_Performed_During_Measurement_Period() => 
		__Has_Kidney_Panel_Performed_During_Measurement_Period.Value;

	private bool? Numerator_Value()
	{
		bool? a_ = this.Has_Kidney_Panel_Performed_During_Measurement_Period();

		return a_;
	}

    [CqlDeclaration("Numerator")]
	public bool? Numerator() => 
		__Numerator.Value;

	private Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Ethnicity_Value()
	{
		Tuple_DMgHTLENEHBHWJISQgKZGZVMB a_ = SupplementalDataElements_3_4_000.SDE_Ethnicity();

		return a_;
	}

    [CqlDeclaration("SDE Ethnicity")]
	public Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Ethnicity() => 
		__SDE_Ethnicity.Value;

	private IEnumerable<Tuple_GDKRbfOIHhLGieQSVDEMIaDPX> SDE_Payer_Value()
	{
		IEnumerable<Tuple_GDKRbfOIHhLGieQSVDEMIaDPX> a_ = SupplementalDataElements_3_4_000.SDE_Payer();

		return a_;
	}

    [CqlDeclaration("SDE Payer")]
	public IEnumerable<Tuple_GDKRbfOIHhLGieQSVDEMIaDPX> SDE_Payer() => 
		__SDE_Payer.Value;

	private Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Race_Value()
	{
		Tuple_DMgHTLENEHBHWJISQgKZGZVMB a_ = SupplementalDataElements_3_4_000.SDE_Race();

		return a_;
	}

    [CqlDeclaration("SDE Race")]
	public Tuple_DMgHTLENEHBHWJISQgKZGZVMB SDE_Race() => 
		__SDE_Race.Value;

	private CqlCode SDE_Sex_Value()
	{
		CqlCode a_ = SupplementalDataElements_3_4_000.SDE_Sex();

		return a_;
	}

    [CqlDeclaration("SDE Sex")]
	public CqlCode SDE_Sex() => 
		__SDE_Sex.Value;

}
